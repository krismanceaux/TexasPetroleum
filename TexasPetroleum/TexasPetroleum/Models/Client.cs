using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexasPetroleum.Models
{
    public class Client
    {
        ublic Client()
        {
            ClientId = Guid.NewGuid();
            Address = new Address();
            FuelQuotes = new List<FuelQuote>();
        }

        [Required]
        public Guid ClientId { get; set; }


        [Required]
        public string Name { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<FuelQuote> FuelQuotes { get; set; }
    }
}