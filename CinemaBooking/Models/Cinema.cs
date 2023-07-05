using CinemaBooking.Enums;
using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.Models
{
    public class Cinema
    {
        [Key]
        public int ID { get; set; }

        [Required (ErrorMessage = "Name is Requird")]
        [MaxLength(20),MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Description is Required")]
        [StringLength(100, MinimumLength = 10)]
        public string Descripition { get; set; }
    
        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.jpeg)$", ErrorMessage = "Only Image files allowed and should be 5MB or lower.")]
        public string Logo { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();


    }
}
