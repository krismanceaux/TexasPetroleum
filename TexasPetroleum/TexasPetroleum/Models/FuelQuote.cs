namespace TexasPetroleum
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FuelQuote
    {
        private double Value;

        public int Id { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime TimeCreated { get; set; }

        public double SuggestedPrice { get; set; } = 2.5;

        public double GallonsRequested { get; set; }

        public Address DeliveryAddress { get; set; }

        public Client Client { get; set; }

        public double TotalPrice
        {
            get
            {
                return GallonsRequested * SuggestedPrice;
            }
            set
            {
                this.Value = value;
            }
        }
    }
}