using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TexasPetroleum.Models
{
    public class FuelQuote
    {
        //may have to delete
        private double gallons = -1;

        public FuelQuote()
        {
            QuoteId = Guid.NewGuid();
        }

        [Key]
        public Guid QuoteId { get; set; }

        public Address DeliveryAddress { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime TimeCreated { get; set; }

        public double SuggestedPrice { get; set; }

        //May have to change back to just get; set;
        public double GallonsRequested
        {
            get
            {
                return gallons;
            }
                
            set
            {
                if (value > 0)
                {
                    gallons = value;
                }
                
            }
        }

        public double TotalPrice
        {
            get
            {
                return Math.Round(SuggestedPrice * GallonsRequested, 2);
            }
        }


        [Required]
        public virtual Client Client { get; set; }
    }
}