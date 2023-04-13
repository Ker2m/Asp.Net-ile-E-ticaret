using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace BisikletEshop.Models
{
	public class Siparis
	{
		[ScaffoldColumn(false)]
		public int SiparisId { get; set; }
		[ScaffoldColumn(false)]
		public string? UserId { get; set; } 
		[ScaffoldColumn(false)]
		public DateTime? SiparisTarihi { get; set; }

		public string AdSoyad { get; set; }
		public string TeslimatAdresi { get; set; }
		public string Sehir { get; set; }

		public string TelefonNumarasi { get; set; }
		public string EPostaAdresi { get; set; }
		[ScaffoldColumn(false)]
		public decimal? Tutar { get; set; }


		public string KartNumarası { get; set; }
		[Required(ErrorMessage = "Kerdi Kartı Adı boş geçilemez")]

		public string KartUzerindekiAd { get; set; }
		[Required(ErrorMessage = "Son Kullanma Tarihi boş geçilemez")]

		public string SonKullanmaTarihi { get; set; }
		[Required(ErrorMessage = "Güvenlik Kodu boş geçilemez")]

		public int GüvenlikKodu { get; set; }

		public virtual IEnumerable<SiparisDetay>? SiparisDetaylari { get; set; }
	}
}
