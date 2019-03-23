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
        [Required(ErrorMessage ="Name is required")]
        [StringLength(50,ErrorMessage = "Must be less than 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Address Line 1")]
        [Required(ErrorMessage ="Street address is required")]
        [StringLength(100, ErrorMessage = "Must be less than 100 characters")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(100, ErrorMessage = "Must be less than 100 characters")]
        public string AddressLine2 { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage ="City is required")]
        [StringLength(100, ErrorMessage = "Must be less than 100 characters")]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State selection is required")]
        public StateOptions StateOption { get; set; } = StateOptions.AK;

        [Display(Name = "Zipcode")]
        [Required(ErrorMessage ="Zipcode is required")]
        [StringLength(9, MinimumLength = 5, ErrorMessage = "Must be between 5 and 9 characters in length")]
        public string Zipcode { get; set; }

        public IEnumerable<SelectListItem> StateOptionsSelect { get; set; }
    }
}