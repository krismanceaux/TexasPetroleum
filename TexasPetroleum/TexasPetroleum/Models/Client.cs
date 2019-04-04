namespace TexasPetroleum
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FuelQuote.Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            FuelQuotes = new HashSet<FuelQuote>();
        }

        public int Id { get; set; }

        
        [StringLength(50)]
        public string Name { get; set; }

       
        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [StringLength(100)]
        public string AddressLine2 { get; set; }

       
        [StringLength(100)]
        public string City { get; set; }

       
        [StringLength(2)]
        public string State { get; set; }

       
        [StringLength(9)]
        public string ZipCode { get; set; }

        public int LoginId { get; set; }

        public virtual ClientLogin ClientLogin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FuelQuote> FuelQuotes { get; set; }
    }
}
