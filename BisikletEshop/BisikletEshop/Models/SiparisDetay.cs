namespace BisikletEshop.Models
{
	public class SiparisDetay
	{
		public int SiparisDetayId { get; set; }

		public int UrunId { get; set; }
		public virtual Urun? Urun { get; set; }

		public decimal SatisFiyati { get; set; }
		public int SiparisAdedi { get; set; }


		public int SiparisId { get; set; }
		public Siparis? Siparis { get; set; }
	}
}
