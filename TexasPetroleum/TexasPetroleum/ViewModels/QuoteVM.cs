using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static TexasPetroleum.Enums.DisplayEnums;

namespace TexasPetroleum.ViewModels
{
    public class QuoteVM
    {
        [Display(Name="Delivery Date")]
        [Required(ErrorMessage = "Delivery date is required")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name ="Address Line 1")]
        [Required(ErrorMessage = "Street address is required")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage ="State is required")]
        public string State { get; set; }

        [Display(Name = "Zipcode")]
        [Required(ErrorMessage = "Zipcode is required")]
        public string Zipcode { get; set; }

        [Display(Name = "Price per Gallon")]
        [Required]
        public double SuggestedPrice { get; set; }

        [Display(Name = "Gallons Requested")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Must be greater than 0")]
        [Required(ErrorMessage = "Gallons requested is required")]
        public double GallonsRequested { get; set; }

        [Display(Name = "Total Price")]
        [Required]

        public double TotalPrice
        {
            get;
            set;
            //get
            //{
            //    return Math.Round(SuggestedPrice * GallonsRequested, 2);
            //}
        }


        [Display(Name = "Address")]
        public string AddressString
        {
            get
            {
                return (AddressLine1 + " " + AddressLine2 + ", " + City + ", " + State + " " + Zipcode);
            }
        }
    }
}