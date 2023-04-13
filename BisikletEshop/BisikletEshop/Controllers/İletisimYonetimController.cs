using BisikletEshop.Data;
using BisikletEshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BisikletEshop.Controllers
{
	public class İletisimYonetimController : Controller
	{
		private readonly ApplicationDbContext _context;

		public İletisimYonetimController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: İletisim
		public async Task<IActionResult> Index()
		{
			return _context.İletisim != null ?
						View(await _context.İletisim.ToListAsync()) :
						Problem("Entity set 'ApplicationDbContext.İletisim'  is null.");
		}

		// GET: İletisim/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.İletisim == null)
			{
				return NotFound();
			}

			var İletisim = await _context.İletisim
				.FirstOrDefaultAsync(m => m.İletisimId == id);
			if (İletisim == null)
			{
				return NotFound();
			}

			return View(İletisim);
		}

		// GET: İletisim/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: İletisim/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("İletisimId,AdSoyad,Email,MesajMetni,Tarih,OkunmaTarihi")] İletisim İletisim)
		{
			if (ModelState.IsValid)
			{
				_context.Add(İletisim);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(İletisim);
		}

		// GET: İletisim/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.İletisim == null)
			{
				return NotFound();
			}

			var İletisim = await _context.İletisim.FindAsync(id);
			if (İletisim == null)
			{
				return NotFound();
			}
			return View(İletisim);
		}

		// POST: İletisim/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("İletisimId,AdSoyad,Email,MesajMetni,Tarih,OkunmaTarihi")] İletisim İletisim)
		{
			if (id != İletisim.İletisimId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(İletisim);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!İletisimExists(İletisim.İletisimId))
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
			return View(İletisim);
		}

		// GET: İletisim/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.İletisim == null)
			{
				return NotFound();
			}

			var İletisim = await _context.İletisim
				.FirstOrDefaultAsync(m => m.İletisimId == id);
			if (İletisim == null)
			{
				return NotFound();
			}

			return View(İletisim);
		}

		// POST: İletisim/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.İletisim == null)
			{
				return Problem("Entity set 'ApplicationDbContext.İletisim'  is null.");
			}
			var İletisim = await _context.İletisim.FindAsync(id);
			if (İletisim != null)
			{
				_context.İletisim.Remove(İletisim);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool İletisimExists(int id)
		{
			return (_context.İletisim?.Any(e => e.İletisimId == id)).GetValueOrDefault();
		}
	}
}
