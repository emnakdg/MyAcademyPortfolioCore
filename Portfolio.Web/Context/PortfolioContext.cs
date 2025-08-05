using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Context
{
    public class PortfolioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-7CKJMG6;Database=MyAcademyPortfolioDb;integrated security=true;trustServerCertificate=true");
        }

        //pluralize
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Project> Projects { get; set; }


    }
}
