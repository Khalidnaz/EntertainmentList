using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace entertainmentList.Models
{
    public class movieList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MovieName { get;set; }
        public int ReleaseDate { get; set; }
        public int Rating { get; set; }
    }
}