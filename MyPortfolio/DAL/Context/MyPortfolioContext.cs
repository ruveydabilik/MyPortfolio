using Microsoft.EntityFrameworkCore;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.DAL.Context
{
    public class MyPortfolioContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public MyPortfolioContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // json'daki bağlantı dizesini Dependency Injection (DI) ile alıyoruz
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
    }
}
