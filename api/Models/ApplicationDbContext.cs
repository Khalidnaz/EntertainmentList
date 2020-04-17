using api.Models;
using Microsoft.EntityFrameworkCore;

namespace EntertainmentList.Models
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