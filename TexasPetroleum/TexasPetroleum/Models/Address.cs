using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TexasPetroleum.Models
{
    public class Address
    {
        public Address()
        {
            AddressLine1 = String.Empty;
            City = String.Empty;
            State = "AK";
            Zipcode = String.Empty;
        }

        [Key,ForeignKey("Client")]
        public Guid Id { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        public virtual Client Client { get; set; }
    }
}
