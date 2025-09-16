using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class BannerController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var banner = context.Banners.ToList();
            return View(banner);
        }

        public IActionResult UpdateBanner(int id)
        {
            var banner = context.Banners.Find(id);
            return View(banner);
        }

        [HttpPost]
        public IActionResult UpdateBanner(Banner banner)
        {
            if (!ModelState.IsValid)
            {
                return View(banner);
            }
            context.Banners.Update(banner);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
