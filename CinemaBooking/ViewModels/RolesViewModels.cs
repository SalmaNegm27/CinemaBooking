using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.ViewModels
{
    public class RolesViewModels
    {
        [Required]
        public string RoleName { get; set; }
    }
}
