using System.ComponentModel.DataAnnotations;

namespace BisikletEshop.Models
{
	public class Urun
	{
		public int UrunId { get; set; } 
		public string Ad { get; set; }
		public decimal Fiyat { get; set; }
		public string? Aciklama { get; set; }
		public string? Model { get; set; }


		[Display(Name = "Görsel")]
		public string? Foto { get; set; }

		public int KategoriId { get; set; }
		public virtual Kategori? Kategori { get; set; }
		public int MarkaId { get; set; }
		public virtual Marka? Marka { get; set; }
	}
}
