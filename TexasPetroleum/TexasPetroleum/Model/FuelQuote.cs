namespace TexasPetroleum
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FuelQuote
    {
        [Key]
        public Guid QuoteID { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime? TimeCreated { get; set; }

        public double? SuggestedPrice { get; set; }

        public double? GallonsRequested { get; set; }

        public Guid? Client_ClientID { get; set; }

        public Guid? AddressID { get; set; }

        public virtual Client Client { get; set; }
    }
}
