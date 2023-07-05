using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.Models
{
    public class Producer
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Actor Bio")]
        public string Bio { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.jpeg)$", ErrorMessage = "Only Image files allowed and should be 5MB or lower.")]
        public string ImagePath { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
