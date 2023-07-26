using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.Data.ViewModels
{
    public class RolesViewModels
    {
        [Required]
        public string RoleName { get; set; }
    }
}
