using EntertainmentList.Models.DataModel;
using api.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace EntertainmentList.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		//will delete later, created for testing
		public DbSet<MovieList> MovieList { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<Movie> Movies { get; set; }
		
	}
}