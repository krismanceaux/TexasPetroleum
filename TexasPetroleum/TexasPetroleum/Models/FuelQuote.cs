namespace TexasPetroleum
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FuelQuote.FuelQuote")]
    public partial class FuelQuote
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DevliveryDate { get; set; }

        public double SuggestedPrice { get; set; }

        public double GallonsRequested { get; set; }

        public double TotalPrice { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
