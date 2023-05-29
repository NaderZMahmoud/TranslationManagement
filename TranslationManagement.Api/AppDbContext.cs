using Microsoft.EntityFrameworkCore;
using TranslationManagement.Api.Controlers;
using TranslationManagement.Api.Controllers;

namespace TranslationManagement.Api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.TranslationJob> TranslationJobs { get; set; }
        public DbSet<Models.TranslatorModel> Translators { get; set; }
    }
}