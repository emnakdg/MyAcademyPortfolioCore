using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.Controllers
{
    public class StatisticsController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            ViewBag.projectCount = context.Projects.Count();
            ViewBag.SkillAverage = context.Skills.Any() ? context.Skills.Average(x => x.Percentage).ToString("00.00") : 0.0.ToString("00.00");
            ViewBag.UnreadMessageCount = context.UserMessages.Count(x => x.IsRead == false);
            ViewBag.LastMessageOwner = context.UserMessages.OrderByDescending(x => x.UserMessageId).Select(x => x.Name).FirstOrDefault();
            var startYear = context.Experiences.Min(x => x.StartYear);
            ViewBag.ExperienceYear = DateTime.Now.Year - startYear;
            ViewBag.CompanyCount = context.Experiences.Select(x => x.Company).Distinct().Count();
            ViewBag.ReviewAverage = context.Testimonials.Any() ? context.Testimonials.Average(x => x.Review).ToString("0.0") : "Değerlendirme Yapılmadı";
            ViewBag.MaxReviewOwner = context.Testimonials.OrderByDescending(x => x.Review).Select(x => x.Name).FirstOrDefault();
            ViewBag.TestimonialCount = context.Testimonials.Count();
            ViewBag.EducationCount = context.Educations.Count();
            ViewBag.CategoryCount = context.Categories.Count();
            return View();
        }
    }
}
