using entertainmentList.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace entertainmentList.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<MovieList> MovieList { get; set; }

				public DbSet<NewUser> Users { get; set; }
    }
}