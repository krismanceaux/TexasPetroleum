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

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime DeliveryDate { get; set; }

        public double SuggestedPrice { get; set; }

        public double GallonsRequested { get; set; }

        public double TotalPrice { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
