using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			
		}

		public DbSet<Movie> Movies { get; set; }

		public DbSet<User> Users { get; set; }
	}
}