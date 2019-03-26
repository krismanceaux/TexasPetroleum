namespace TexasPetroleum
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Address
    {
        public Address()
        {
            Id = -1;
            AddressLine1 = String.Empty;
            AddressLine2 = String.Empty;
            City = String.Empty;
            State = String.Empty;
            Zipcode = String.Empty;
        }

        public int Id { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

    }
}