using System;
using System.ComponentModel.DataAnnotations;

namespace SavoirApp.Models
{
    public enum Brand
    {
        [Display(Name = "Zara")]
        ZARA,
        [Display(Name = "Bershka")]
        BERSHKA,
        [Display(Name = "Stradivarius")]
        STRADIVARIUS,
        [Display(Name = "Koton")]
        KOTON,
        [Display(Name = "Benetton")]
        BENETTON,
        [Display(Name = "Tiffany")]
        TIFFANY
    }
}
