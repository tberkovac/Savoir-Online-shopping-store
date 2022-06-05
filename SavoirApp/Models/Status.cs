using System;
using System.ComponentModel.DataAnnotations;

namespace SavoirApp.Models
{
    public enum Status
    {
        [Display(Name = "Order placed")]
        ORDER_PLACED,
        [Display(Name = "Packed")]
        PACKED,
        [Display(Name = "Shipped")]
        SHIPPED,
        [Display(Name = "Delivered")]
        DELIVERED
    }
}
