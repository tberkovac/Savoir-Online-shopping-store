using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavoirApp.Models
{
    public class Wishlist
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Item")]
        public int IDItem { get; set; }
        public Item Item { get; set; }

        public Wishlist()
        {
        }
    }
}

// user0 ID: 16907ab4 - 843f - 491b - bb68 - 21bfd8d5e8c1 , ROLE ID 2
// admin ID: 30b6965b-f9b2-49f7-b0b4-01d8a299d928, ROLE ID 1
// vipuser0 ID: 8bf03ba5-7848-4544-8265-1ea2356312d7, ROLE ID 3

/*
 * Zatim treba da definisemo korisnicke uloge,
 * pogledamo sta imamo u AspNetRoles
 */
