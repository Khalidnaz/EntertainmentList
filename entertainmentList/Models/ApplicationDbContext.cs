using Microsoft.EntityFrameworkCore;

namespace entertainmentList.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<movieList> movieList { get; set; }
    }
}