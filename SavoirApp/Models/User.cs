using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavoirApp.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public double MoneySpent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [ForeignKey("AspNetUsers")]
        public int FKASPUserId { get; set; }

        [ForeignKey("Wishlists")]
        public int FKWishlistId { get; set; }
        public Wishlist Wishlist { get; set; }

        public User()
        {
        }
    }
}
