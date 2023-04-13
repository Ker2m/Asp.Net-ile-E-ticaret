using BisikletEshop.Data;
using BisikletEshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BisikletEshop.Controllers
{
    public class İletisimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public İletisimController(ApplicationDbContext context)
        {
            _context = context;
        }




        // GET: İletisim/Create
        public IActionResult Index()
        {
            return View();
        }

        // POST: İletisim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("İletisimId,AdSoyad,Email,MesajMetni,Tarih,OkunmaTarihi")] İletisim İletisim)
        {
            if (ModelState.IsValid)
            {
                İletisim.Tarih = DateTime.Now;
                _context.Add(İletisim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(İletisim);
        }

        private bool İletisimExists(int id)
        {
            return (_context.İletisim?.Any(e => e.İletisimId == id)).GetValueOrDefault();
        }
    }
}

