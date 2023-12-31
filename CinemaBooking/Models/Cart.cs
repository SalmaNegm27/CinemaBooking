﻿using CinemaBooking.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaBooking.Models
{
    public class Cart
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<CartItemsHistory> CartItemsHistories { get; set; }
        public DateTime CartDate { get; set; }

        //public int CartItemCount => CartItems?.Count ?? 0;
        //public int Count { get; set; }



    }
}
