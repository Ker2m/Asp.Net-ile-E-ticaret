using BisikletEshop.Data;
using Microsoft.AspNetCore.Mvc;

namespace BisikletEshop.Controllers
{
	public class AksesuarController : Controller
	{


		private readonly ApplicationDbContext _db;

		public AksesuarController(ApplicationDbContext context)
		{
			_db = context;
		}
		public IActionResult Index()
		{

			var Urunler = _db.Urunler.ToList();

			return View(Urunler);

		}

		public IActionResult Parca()
		{

			var Urunler = _db.Urunler.ToList();

			return View(Urunler);

		}
	}
}
