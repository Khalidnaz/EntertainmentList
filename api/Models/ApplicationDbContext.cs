using api.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace EntertainmentList.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }

		public DbSet<Movie> Movies { get; set; }
		
		public DbSet<TvShow> TvShows { get; set; }
		
	}
}