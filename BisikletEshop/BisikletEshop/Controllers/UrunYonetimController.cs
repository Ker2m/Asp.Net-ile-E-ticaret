using BisikletEshop.Data;
using BisikletEshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BisikletEshop.Controllers
{
	public class UrunYonetimController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _environmet;

		public UrunYonetimController(ApplicationDbContext context, IWebHostEnvironment environment)
		{
			_context = context;
			_environmet = environment;
		}

		// GET: UrunYonetim
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Urunler.Include(u => u.Kategori).Include(u => u.Marka);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: UrunYonetim/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Urunler == null)
			{
				return NotFound();
			}

			var urun = await _context.Urunler
				.Include(u => u.Kategori)
				.Include(u => u.Marka)
				.FirstOrDefaultAsync(m => m.UrunId == id);
			if (urun == null)
			{
				return NotFound();
			}

			return View(urun);
		}

		// GET: UrunYonetim/Create
		public IActionResult Create()
		{
			ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "Ad");
			ViewData["MarkaId"] = new SelectList(_context.Marka, "MarkaId", "Ad");
			return View();
		}

		// POST: UrunYonetim/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Ad,Fiyat,Aciklama,Model,Foto,KategoriId,MarkaId")]
		Urun urun, IFormFile Foto)
		{
			if (ModelState.IsValid)
			{

				var photoName = Guid.NewGuid().ToString()
					 + System.IO.Path.GetExtension(Foto.FileName);

				using (var strem = new FileStream(
					Path.Combine(_environmet.WebRootPath, "img/", photoName),
					FileMode.Create))
				{
					await Foto.CopyToAsync(strem);
					urun.Foto = photoName;
				}

				_context.Add(urun);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "Ad", urun.KategoriId);
			return View(urun);
		}



		// GET: UrunYonetim/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Urunler == null)
			{
				return NotFound();
			}

			var urun = await _context.Urunler.FindAsync(id);
			if (urun == null)
			{
				return NotFound();
			}
			ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "Ad", urun.KategoriId);
			ViewData["MarkaId"] = new SelectList(_context.Marka, "MarkaId", "Ad", urun.MarkaId);
			return View(urun);
		}

		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("UrunId,Ad,Fiyat,Aciklama,Model,Foto,KategoriId,MarkaId")] Urun urun)
		{
			if (id != urun.UrunId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(urun);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!UrunExists(urun.UrunId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "KategoriId", urun.KategoriId);
			ViewData["MarkaId"] = new SelectList(_context.Marka, "MarkaId", "MarkaIdAd", urun.MarkaId);
			return View(urun);
		}

		// GET: UrunYonetim/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Urunler == null)
			{
				return NotFound();
			}

			var urun = await _context.Urunler
				.Include(u => u.Kategori)
				.Include(u => u.Marka)
				.FirstOrDefaultAsync(m => m.UrunId == id);
			if (urun == null)
			{
				return NotFound();
			}

			return View(urun);
		}

		// POST: UrunYonetim/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Urunler == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Urunler'  is null.");
			}
			var urun = await _context.Urunler.FindAsync(id);
			if (urun != null)
			{
				_context.Urunler.Remove(urun);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool UrunExists(int id)
		{
			return (_context.Urunler?.Any(e => e.UrunId == id)).GetValueOrDefault();
		}
	}
}
