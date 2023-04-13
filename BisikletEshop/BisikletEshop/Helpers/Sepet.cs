using BisikletEshop.Data;
using BisikletEshop.Models;
using Microsoft.EntityFrameworkCore;

namespace BisikletEshop.Helpers
{
	public class Sepet
	{
		ApplicationDbContext context;
		public string SepetAdi { get; set; }

		const string SepetSessionKey = "SepetAdi";

		private Sepet(ApplicationDbContext ctx)
		{
			this.context = ctx;
		}

		public static Sepet SepetiGetir(ApplicationDbContext db, HttpContext http)
		{


			Sepet spt = new Sepet(db);
			spt.SepetAdi = spt.SepetAdiGetir(http);
			return spt;
		}

		private string SepetAdiGetir(HttpContext http)
		{
			// hafızada sepet var ise varolani getir
			string sepetAdi = http.Session.GetString(SepetSessionKey);

			// yok ise,
			if (sepetAdi == null)
			{

				string kullanicininAdi = http.User.Identity.Name;


				if (String.IsNullOrWhiteSpace(kullanicininAdi))
				{

					Guid tempCartId = Guid.NewGuid();

					http.Session.SetString(SepetSessionKey, tempCartId.ToString());
				}
				else
				{

					http.Session.SetString(SepetSessionKey, kullanicininAdi);
				}
			}


			return http.Session.GetString(SepetSessionKey);
		}

		public void SepeteAt(Urun urn)
		{

			SepetElemani urun = context.SepetElemanlari.SingleOrDefault(c => c.SepetAd == this.SepetAdi && c.Id == urn.UrunId);


			if (urun == null)
			{

				urun = new SepetElemani()
				{
					UrunId = urn.UrunId,
					SepetAd = this.SepetAdi,
					Adet = 1,
					EklenmeTarihi = DateTime.Now,
					SatisFiyati = urn.Fiyat
				};

				context.SepetElemanlari.Add(urun);
			}
			else
			{
				// Ürün sepette varsa adedi 1 artir
				urun.Adet++;
			}

			// veri tabanina kaydet
			context.SaveChanges();
		}

		// sepeti tamamen bosaltan kod
		public void SepetiBosalt()
		{
			// bu sepetteki tum urunleri getir
			// yani; bu isimdeki sepete ait veri tabanında kayitli urunleri getir
			IQueryable<SepetElemani> sepettekiElemenlar = context.SepetElemanlari.Where(e => e.SepetAd == this.SepetAdi);

			// döngüye git ve adetlerine bakmaksızın her urun bilgisini tablodan tek tek sil
			foreach (SepetElemani urun in sepettekiElemenlar)
			{
				context.SepetElemanlari.Remove(urun);
			}

			// degisiklikleri veri tabanına yansıt (delete from tabloadı)
			context.SaveChanges();
		}

		public int SepettenUrunCikar(Urun k)
		{
			return SepettenUrunCikar(k.UrunId);
		}


		/// <summary>
		/// sepetten urun cikartır, kalan adedi return eder
		/// </summary>
		/// <param name="id">KitapId degeri</param>
		/// <returns></returns>
		public int SepettenUrunCikar(int id)
		{
			// Get the cart
			SepetElemani cikarilmakIstenenUrun = context.SepetElemanlari.SingleOrDefault(se => se.SepetAd == this.SepetAdi && se.Id == id);

			int kalanAdet = 0;

			if (cikarilmakIstenenUrun != null)
			{
				if (cikarilmakIstenenUrun.Adet > 1)
				{
					cikarilmakIstenenUrun.Adet--;
					kalanAdet = cikarilmakIstenenUrun.Adet;
				}
				else
				{
					context.SepetElemanlari.Remove(cikarilmakIstenenUrun);
				}
				// Save changes
				context.SaveChanges();
			}

			return kalanAdet;
		}


		// Sepet Elemanlarını getir (ihtiyac duyulan tum bilgiler geliyor mu???)
		public List<SepetElemani> SepettekiElemanlariGetir()
		{
			return context.SepetElemanlari.Where(e => e.SepetAd == this.SepetAdi).Include(e => e.Urun).ToList();
		}

		public int SepettekiElemanAdediniGetir()
		{
		

			// NOT: satır bulunamazsa error vermemeli, 0 dönmeli
			var urunler = context.SepetElemanlari.Where(e => e.SepetAd == this.SepetAdi);
			if (urunler == null)
			{
				return 0;
			}

			return urunler.Sum(u => u.Adet);
		}

		public decimal SepetTutariniHesapla()
		{
			var urunler = SepettekiElemanlariGetir();
			if (urunler == null)
			{
				return 0;
			}

			return urunler.Sum(u => u.Adet * u.SatisFiyati);
		}

		// TODO: login oldugumuz anda bu metot cagrilmali. register ya da aktivasyonda auto login var ise, o metodun icinde de bu metot calismali.
		public void SepetiSahiplen(string userName)
		{
			var elemanlar = context.SepetElemanlari.Where(e => e.SepetAd == this.SepetAdi);
			foreach (SepetElemani eleman in elemanlar)
			{
				eleman.SepetAd = userName;
			}

			context.SaveChanges();
		}

		public int SiparisinDetaylariniEkle(Siparis siparis)
		{
			var urunler = SepettekiElemanlariGetir();

			foreach (SepetElemani urun in urunler)
			{
				// urunden siparis detayi elde et
				// siparis detayini ile siparisi birbirine bagla
				SiparisDetay sd = new SiparisDetay() { UrunId = urun.UrunId, SatisFiyati = urun.SatisFiyati, SiparisId = siparis.SiparisId, SiparisAdedi = urun.Adet };

				// detayi veri tabanına ekle
				context.SiparisDetaylari.Add(sd);


			}

			context.SaveChanges();

			SepetiBosalt();

			return siparis.SiparisId;
		}
	}
}
