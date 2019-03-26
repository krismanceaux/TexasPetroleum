using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TexasPetroleum.Controllers;
using Xunit;

namespace TexasPetroleum.Tests
{
    public class ProfileControllerTest
    {
        [Fact]
        public void Index_NotNull()
        {
            //Arrange
             var controller = new ProfileController();

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.NotNull(result); 
        }
    }
}
