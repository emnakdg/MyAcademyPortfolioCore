using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultStatsComponent(PortfolioContext context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.projectCount = context.Projects.Count();
            ViewBag.EducationCount = context.Educations.Count();
            ViewBag.testimonialCount = context.Testimonials.Count();
            ViewBag.CategoryCount = context.Categories.Count();
            return View();
        }
    }
}
