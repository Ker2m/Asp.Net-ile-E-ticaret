using BisikletEshop.Data;
using BisikletEshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BisikletEshop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminAnasayfa : Controller
    {
      
            private readonly ApplicationDbContext _db;
            AnaSayfaCokluListeleme _As = new AnaSayfaCokluListeleme();

            public AdminAnasayfa(ApplicationDbContext context)
            {
                _db = context;
            }
            public IActionResult Index()
            {
                _As.Kategoriler = _db.Kategoriler.ToList();
                _As.Urunler = _db.Urunler.ToList();
                //_As.Bloglar = _db.Bloglar.ToList();
               
                return View(_As);


            }
    }
}
