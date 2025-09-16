using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class SkillController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var skills = context.Skills.ToList();
            return View(skills);
        }

        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View(skill);
            }
            context.Skills.Add(skill);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var skill = context.Skills.Find(id);
            if (skill == null)
            {
                return NotFound();
            }
            context.Skills.Remove(skill);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateSkill(int id)
        {
            var skill = context.Skills.Find(id);
            return View(skill);
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View(skill);
            }
            context.Skills.Update(skill);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
