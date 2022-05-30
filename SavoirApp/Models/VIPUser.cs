using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SavoirApp.Models
{
    public class VIPUser
    {
        [Key]
        public string ID { get; set; }
        public double MoneySpent { get; set; }
    //    public List<Item> WishList { get; set; }   treba obrisati
    //    public List<Order> Orders { get; set; }    treba obrisati

        public VIPUser()
        {
        }
    }
}
