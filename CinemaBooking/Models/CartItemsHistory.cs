using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaBooking.Models
{
    public class CartItemsHistory
    {
        [Key]
        public int ID { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public string MovieName { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [ForeignKey("Cart")]
        public int? CartId { get; set; }
        public Cart? Cart { get; set; }
        public DateTime CheckoutDate { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
   
    }
}
