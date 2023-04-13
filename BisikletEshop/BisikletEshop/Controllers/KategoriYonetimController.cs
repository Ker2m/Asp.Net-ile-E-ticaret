using BisikletEshop.Data;
using BisikletEshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BisikletEshop.Controllers
{
	public class KategoriYonetimController : Controller
	{
		private readonly ApplicationDbContext _context;

		public KategoriYonetimController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: KategoriYonetiöm
		public async Task<IActionResult> Index()
		{
			return _context.Kategoriler != null ?
						View(await _context.Kategoriler.ToListAsync()) :
						Problem("Entity set 'ApplicationDbContext.Kategoriler'  is null.");
		}

		// GET: KategoriYonetiöm/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Kategoriler == null)
			{
				return NotFound();
			}

			var kategori = await _context.Kategoriler
				.FirstOrDefaultAsync(m => m.KategoriId == id);
			if (kategori == null)
			{
				return NotFound();
			}

			return View(kategori);
		}

		// GET: KategoriYonetiöm/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: KategoriYonetiöm/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("KategoriId,Ad,foto,Aciklama")] Kategori kategori)
		{
			if (ModelState.IsValid)
			{
				_context.Add(kategori);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(kategori);
		}

		// GET: KategoriYonetiöm/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Kategoriler == null)
			{
				return NotFound();
			}

			var kategori = await _context.Kategoriler.FindAsync(id);
			if (kategori == null)
			{
				return NotFound();
			}
			return View(kategori);
		}

		// POST: KategoriYonetiöm/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("KategoriId,Ad,foto,Aciklama")] Kategori kategori)
		{
			if (id != kategori.KategoriId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(kategori);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!KategoriExists(kategori.KategoriId))
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
			return View(kategori);
		}

		// GET: KategoriYonetiöm/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Kategoriler == null)
			{
				return NotFound();
			}

			var kategori = await _context.Kategoriler
				.FirstOrDefaultAsync(m => m.KategoriId == id);
			if (kategori == null)
			{
				return NotFound();
			}

			return View(kategori);
		}

		// POST: KategoriYonetiöm/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Kategoriler == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Kategoriler'  is null.");
			}
			var kategori = await _context.Kategoriler.FindAsync(id);
			if (kategori != null)
			{
				_context.Kategoriler.Remove(kategori);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool KategoriExists(int id)
		{
			return (_context.Kategoriler?.Any(e => e.KategoriId == id)).GetValueOrDefault();
		}
	}
}
