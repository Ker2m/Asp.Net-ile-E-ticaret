using System.ComponentModel.DataAnnotations;

namespace BisikletEshop.Models
{
	public class İletisim
	{
		public int İletisimId { get; set; }


		[Display(Name = "Ad Soyad")]
		public string AdSoyad { get; set; }
		public string Email { get; set; }

		public string MesajMetni { get; set; }

		public DateTime? Tarih { get; set; }
		public DateTime? OkunmaTarihi { get; set; }
	}
}
