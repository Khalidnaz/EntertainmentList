using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
	public class MovieList
	{
		[Key]
		public Guid Id { get; set; }
		
		[Required]
		public string MovieName { get; set; }
		
		public int ReleaseDate { get; set; }
		
		public int Rating { get; set; }

		public string[] Genres { get; set; }
	}
}