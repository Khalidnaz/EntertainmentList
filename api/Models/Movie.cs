using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
	public class Movie
	{
		[Key]
		public int MovieID { get; set; }
		[Required]
		public string Title { get; set; }
		public DateTime ReleaseDate { get; set; }
		public double UserScore { get; set; }
	}
}