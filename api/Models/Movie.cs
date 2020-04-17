using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
	public class Movie
	{
		[Key]
		public Guid Id { get; set; }
		
		public string MovieName { get; set; }
		
		public int ReleaseDate { get; set; }
		
		public int Rating { get; set; }

		public string[] Genres { get; set; }
	}
}