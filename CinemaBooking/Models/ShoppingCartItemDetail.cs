using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.Models
{
    public class ShoppingCartItemDetail
    {
        [Key]
        public int ID { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }

    }
}
