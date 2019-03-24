using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static TexasPetroleum.Enums.DisplayEnums;

namespace TexasPetroleum.ViewModels
{
    public class ProfileVM
    {
        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "Must be less than 50 characters")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Display(Name = "Address Line 1")]
        [StringLength(100, ErrorMessage = "Must be less than 100 characters")]
        [Required(ErrorMessage ="Street address is required")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(100, ErrorMessage = "Must be less than 100 characters")]
        public string AddressLine2 { get; set; }

        [Display(Name = "City")]
        [StringLength(100, ErrorMessage = "Must be less than 100 characters")]
        [Required(ErrorMessage ="City is required")]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State selection is required")]
        public StateOptions StateOption { get; set; } = StateOptions.AK;

        [Display(Name = "Zipcode")]
        [StringLength(9, MinimumLength = 5, ErrorMessage = "Must be between 5 and 9 characters in length")]
        [Required(ErrorMessage ="Zipcode is required")]
        public string Zipcode { get; set; }

        public IEnumerable<SelectListItem> StateOptionsSelect { get; set; }
    }
}