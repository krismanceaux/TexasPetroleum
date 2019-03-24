using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TexasPetroleum.Tests
{
    public class FuelQuoteTests
    {
        [Fact]
        public void TotalPrice_ShouldCalculate()
        {
            //Arrange
            FuelQuote newQuote = new FuelQuote();
            newQuote.SuggestedPrice = 2;
            newQuote.GallonsRequested = 10;
            double expectedValue = 20;
            //Act
            double actualValue = newQuote.TotalPrice;
            //Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GallonsRequested_ShouldBeGreaterThanZero()
        {
            //Arrange
            FuelQuote newQuote = new FuelQuote();
            newQuote.GallonsRequested = 5;
            double expectedValue = 5;
            //Act
            double actualValue = newQuote.GallonsRequested;
            //Assert
            Assert.Equal(expectedValue, actualValue);
        }
    }
}
