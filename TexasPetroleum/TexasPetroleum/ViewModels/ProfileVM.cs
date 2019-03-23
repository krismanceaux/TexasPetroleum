using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TexasPetroleum.ViewModels
{
    public class ProfileVM
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Street address is required")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required(ErrorMessage ="City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State selection is required")]
        public StateOptions StateOption { get; set; }

        [Required(ErrorMessage ="Zipcode is required")]
        public string Zipcode { get; set; }
    }
}