using api.Models;
using api.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			
		}

		public DbSet<User> users { get; set; }

		public DbSet<Movie> movies { get; set; }
		
		public DbSet<TvShow> tvshows { get; set; }
		
	}
}