using EntertainmentList.Models;
using Microsoft.EntityFrameworkCore;

namespace EntertainmentList.Repositories
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<MovieList> MovieList { get; set; }

		public DbSet<User> Users { get; set; }
	}
}