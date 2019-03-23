using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TexasPetroleum.Models
{
    public class Client
    {
        public Client()
        {
            ClientId = Guid.NewGuid();
            Address = new Address();
            FuelQuotes = new List<FuelQuote>();
        }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Name { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<FuelQuote> FuelQuotes { get; set; }
    }
}