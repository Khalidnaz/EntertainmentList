using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models.Movies
{
	public class Movie
	{
		[Key]
		public int MovieID { get; set; }
		
		public string Title { get; set; }

		public DateTime ReleaseDate { get; set; }
		
		public double UserScore { get; set; }
	}
}