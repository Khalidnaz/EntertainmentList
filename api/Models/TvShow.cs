using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
	public class TvShow
	{
		[Key]
		public int TvShowID { get; set; }
		
		public string Title { get; set; }

		public DateTime ReleaseDate { get; set; }
		
		public double UserScore { get; set; }
	}
}