using System;
using System.ComponentModel.DataAnnotations;

namespace SavoirApp.Models
{
    public enum Gender
    {
        [Display(Name = "Male")]
        MALE,
        [Display(Name = "Female")]
        FEMALE
    }
}
