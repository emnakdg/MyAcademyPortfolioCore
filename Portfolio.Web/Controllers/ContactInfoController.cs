using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.Controllers
{
    public class ContactInfoController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var contactInfos = context.ContactInfos.ToList();
            return View(contactInfos);
        }

        public IActionResult UpdateContactInfo(int id)
        {
            var contactInfo = context.ContactInfos.Find(id);
            return View(contactInfo);
        }

        [HttpPost]
        public IActionResult UpdateContactInfo(Entities.ContactInfo contactInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(contactInfo);
            }
            context.ContactInfos.Update(contactInfo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
