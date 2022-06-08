using System;
using System.ComponentModel.DataAnnotations;

namespace SavoirApp.Models
{
    public enum PayingOptions
    {
        [Display(Name = "Credit Card")]
        CREDIT_CARD,
        [Display(Name = "Payment on delivery")]
        PAYMENT_ON_DELIVERY
    }
}
