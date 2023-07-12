using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaBooking.Models
{
    public class CartItem
    {
        [Key]
        public int ID { get; set; }
        public double Price { get; set; }
        public int  Amount  { get; set; }

        public double Total { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
       
        public Movie Movie { get; set; }
    }
}
