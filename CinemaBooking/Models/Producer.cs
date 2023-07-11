using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaBooking.Models
{
    public class Producer
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(20), MinLength(3)]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Actor Bio")]
        [StringLength(100, MinimumLength = 10)]
        public string Bio { get; set; }

        [DisplayName("Upload File")]
        //[Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.jpeg)$", ErrorMessage = "Only Image files allowed and should be 5MB or lower.")]
        public string? ImagePath { get; set; }


        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();

    }
}
