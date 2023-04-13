using BisikletEshop.Data;
using BisikletEshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BisikletEshop.Controllers
{
	public class MarkaYonetimController : Controller
	{
		private readonly ApplicationDbContext _context;

		public MarkaYonetimController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: MarkaYonetim
		public async Task<IActionResult> Index()
		{
			return _context.Marka != null ?
						View(await _context.Marka.ToListAsync()) :
						Problem("Entity set 'ApplicationDbContext.Marka'  is null.");
		}

		// GET: MarkaYonetim/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Marka == null)
			{
				return NotFound();
			}

			var marka = await _context.Marka
				.FirstOrDefaultAsync(m => m.MarkaId == id);
			if (marka == null)
			{
				return NotFound();
			}

			return View(marka);
		}

		// GET: MarkaYonetim/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: MarkaYonetim/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("MarkaId,Ad")] Marka marka)
		{
			if (ModelState.IsValid)
			{
				_context.Add(marka);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(marka);
		}

		// GET: MarkaYonetim/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Marka == null)
			{
				return NotFound();
			}

			var marka = await _context.Marka.FindAsync(id);
			if (marka == null)
			{
				return NotFound();
			}
			return View(marka);
		}

		// POST: MarkaYonetim/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("MarkaId,Ad")] Marka marka)
		{
			if (id != marka.MarkaId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(marka);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!MarkaExists(marka.MarkaId))
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
			return View(marka);
		}

		// GET: MarkaYonetim/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Marka == null)
			{
				return NotFound();
			}

			var marka = await _context.Marka
				.FirstOrDefaultAsync(m => m.MarkaId == id);
			if (marka == null)
			{
				return NotFound();
			}

			return View(marka);
		}

		// POST: MarkaYonetim/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Marka == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Marka'  is null.");
			}
			var marka = await _context.Marka.FindAsync(id);
			if (marka != null)
			{
				_context.Marka.Remove(marka);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool MarkaExists(int id)
		{
			return (_context.Marka?.Any(e => e.MarkaId == id)).GetValueOrDefault();
		}
	}
}
