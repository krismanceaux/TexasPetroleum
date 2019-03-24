namespace TexasPetroleum
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FuelQuote
    {
        public int Id { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime TimeCreated { get; set; }

        public double SuggestedPrice { get; set; }

        public double GallonsRequested { get; set; }

        public Address DeliveryAddress { get; set; }

        public Client Client { get; set; }

        public double TotalPrice { get; set; }
    }
}