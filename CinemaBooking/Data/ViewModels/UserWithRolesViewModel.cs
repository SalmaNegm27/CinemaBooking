﻿namespace CinemaBooking.Data.ViewModels
{
    public class UserWithRolesViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public List<string> Roles { get; set; }
    }
}
