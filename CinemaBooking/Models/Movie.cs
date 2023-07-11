using CinemaBooking.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaBooking.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of the Movie is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.jpeg)$", ErrorMessage = "Only Image files allowed and should be 5MB or lower.")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        [StringLength(100, MinimumLength = 10)]
        public string Description { get; set; }

        [Required(ErrorMessage = "StartDate is Required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is Required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Price is Required")]

        public double Price { get; set; }
        [Required]
        public MovieCategory MovieCategory { get; set; }

        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        [ForeignKey("Producer")]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

      

        public List<Actor_Movie> Actor_Movies { get; set; } = new List<Actor_Movie>();

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();


    }
}
