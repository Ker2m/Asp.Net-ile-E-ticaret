using BisikletEshop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BisikletEshop.Controllers
{
	public class UrunController : Controller
	{

		private readonly ApplicationDbContext _db;

		public UrunController(ApplicationDbContext context)
		{
			_db = context;
		}

		public IActionResult Index()
		{

			var Urunler = _db.Urunler.ToList();

			return View(Urunler);

		}

		public async Task<IActionResult> UrunDetay(int? id)
		{
			if (id == null || _db.Urunler == null)
			{
				return NotFound();
			}


			var urundt = await _db.Urunler.Where(x => x.UrunId == id).ToListAsync();

			if (urundt == null)
			{
				return NotFound();
			}



			return View(urundt);
		}


	}
}
