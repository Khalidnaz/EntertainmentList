using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models.DataModel
{
    public class TvShow
    {
        [Key]
		public int TvShowID { get; set; }
		[Required]
		public string Title { get; set; }
		public DateTime ReleaseDate { get; set; }
        public double UserScore { get; set; }
    }
}