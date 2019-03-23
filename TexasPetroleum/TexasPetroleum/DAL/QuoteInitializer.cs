using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexasPetroleum.Models;

namespace TexasPetroleum.DAL
{
    public class QuoteInitializer : System.Data.Entity.DropCreateDatabaseAlways<QuoteContext> // DropCreateDatabaseIfModelChanges<QuoteContext> CHANGE WHEN DONE TESTING
    {
        protected override void Seed(QuoteContext context) 
        {
            var addresses = new List<Address>
            {
            new Address {AddressLine1 = "12345 Oak St", City = "Houston", State = "TX", ZipCode = "77777" },
            new Address {AddressLine1 = "23456 Willow Ln", City = "San Antonio", State = "TX", ZipCode = "78910"},
            new Address {AddressLine1 = "34567 Mahogany Ct", City = "Corpus Christi", State = "TX", ZipCode = "71234" }
            };

            var quotes = new List<FuelQuote>
            {
            new FuelQuote { DeliveryAddress = addresses[0], DeliveryDate = DateTime.Parse("2019-02-23"), GallonsRequested = 120, SuggestedPrice = 2.5321, TimeCreated = DateTime.Parse("2019-01-23") },
            new FuelQuote { DeliveryAddress = addresses[0], DeliveryDate = DateTime.Parse("2019-02-25"), GallonsRequested = 170, SuggestedPrice = 2.5123, TimeCreated = DateTime.Parse("2019-01-25") },
            new FuelQuote { DeliveryAddress = addresses[1], DeliveryDate = DateTime.Parse("2019-02-27"), GallonsRequested = 50, SuggestedPrice = 2.5456, TimeCreated = DateTime.Parse("2019-01-27") },
            new FuelQuote { DeliveryAddress = addresses[1], DeliveryDate = DateTime.Parse("2019-01-30"), GallonsRequested = 60, SuggestedPrice = 2.5876, TimeCreated = DateTime.Parse("2018-12-23") },
            new FuelQuote { DeliveryAddress = addresses[1], DeliveryDate = DateTime.Parse("2019-03-13"), GallonsRequested = 40, SuggestedPrice = 2.5987, TimeCreated = DateTime.Parse("2019-02-13") },
            new FuelQuote { DeliveryAddress = addresses[2], DeliveryDate = DateTime.Parse("2019-03-20"), GallonsRequested = 225, SuggestedPrice = 2.512, TimeCreated = DateTime.Parse("2019-02-03")  },
            };

            var clients = new List<Client>
            {
            new Client {Name = "Company A",  Address = addresses[0], FuelQuotes = new List<FuelQuote> { quotes[0], quotes[1] } },
            new Client {Name = "Company B", Address = addresses[1], FuelQuotes = new List<FuelQuote> { quotes[2], quotes[3], quotes[4] } },
            new Client {Name = "Company C", Address = addresses[2], FuelQuotes = new List<FuelQuote> { quotes[5] } },
            };

            clients.ForEach(x => context.Clients.Add(x));
            context.SaveChanges();

        }
    }
}