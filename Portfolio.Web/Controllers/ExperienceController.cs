using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.Controllers
{
    public class ExperienceController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var experiences = context.Experiences.ToList();
            return View(experiences);
        }

        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateExperience(Entities.Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return View(experience);
            }
            context.Experiences.Add(experience);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateExperience(int id)
        {
            var experience = context.Experiences.Find(id);
            return View(experience);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Entities.Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return View(experience);
            }
            context.Experiences.Update(experience);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteExperience(int id)
        {
            var experience = context.Experiences.Find(id);
            context.Experiences.Remove(experience);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
