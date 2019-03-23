using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TexasPetroleum.Models
{
    public class Address
    {
        public Address()
        {
            AddressId = Guid.NewGuid();
            AddressLine1 = String.Empty;
            City = String.Empty;
            State = String.Empty;
            ZipCode = String.Empty;
        }

        [Key]
        public Guid AddressId { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public virtual Client Client { get; set; }
    }
}
