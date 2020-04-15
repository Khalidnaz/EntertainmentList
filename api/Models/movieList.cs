using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntertainmentList.Models
{
    public class MovieList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MovieName { get;set; }
        public int ReleaseDate { get; set; }
        public int Rating { get; set; }
    }
}