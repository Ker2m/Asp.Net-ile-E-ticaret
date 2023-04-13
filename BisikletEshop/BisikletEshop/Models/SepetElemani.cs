namespace BisikletEshop.Models
{
	public class SepetElemani
	{
		public int Id { get; set; }

		public int UrunId { get; set; }
		public virtual Urun? Urun { get; set; }


		public decimal SatisFiyati { get; set; }
		public int Adet { get; set; }
		public string SepetAd { get; set; }
		public DateTime EklenmeTarihi { get; set; }
	}
}
