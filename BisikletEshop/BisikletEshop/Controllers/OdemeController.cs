using BisikletEshop.Data;
using BisikletEshop.Helpers;
using BisikletEshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace BisikletEshop.Controllers
{
    [Authorize]
    public class OdemeController : Controller
    {
        const string PromoCode = "FREE";

        ApplicationDbContext db;

        public OdemeController(ApplicationDbContext context)
        {
            db = context;
        }

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(Siparis sıparis)
        {

            if (!ModelState.IsValid)
            {
                return View(sıparis);
            }

          
            sıparis.UserId = User.Identity.Name;
            sıparis.SiparisTarihi = DateTime.Now;

            //Save Order
            db.Siparisler.Add(sıparis);
            db.SaveChanges();

            //Process the order
            var cart = Sepet.SepetiGetir(db, this.HttpContext);
            decimal tutar = cart.SepetTutariniHesapla();
            cart.SiparisinDetaylariniEkle(sıparis);
            sıparis.Tutar = tutar;
            db.SaveChanges();

            return RedirectToAction("Complete", new { id = sıparis.SiparisId });

        }

        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = db.Siparisler.Any(o => o.SiparisId == id && o.UserId == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
