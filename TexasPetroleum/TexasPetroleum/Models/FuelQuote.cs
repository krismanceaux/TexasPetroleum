using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TexasPetroleum.Models
{
    public class FuelQuote
    {
        public FuelQuote()
        {
            QuoteId = Guid.NewGuid();
        }

        [Key]
        public Guid QuoteId { get; set; }

        public DateTime DeliveryDate { get; set; }

        public Address DeliveryAddress { get; set; }

        public DateTime TimeCreated { get; set; }

        public double SuggestedPrice { get; set; } = 2.5;

        public double GallonsRequested { get; set; }

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