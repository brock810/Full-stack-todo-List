using Microsoft.EntityFrameworkCore;
using WebApplication7000.Pages.Model;

namespace WebApplication7000
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }

        
    }
}
