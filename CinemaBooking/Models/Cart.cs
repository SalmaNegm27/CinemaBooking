namespace CinemaBooking.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public IEnumerable<CartItem> Items { get; set; }

        
    }
}
