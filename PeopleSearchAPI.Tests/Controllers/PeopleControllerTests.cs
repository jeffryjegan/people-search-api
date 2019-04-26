using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearchAPI.Controllers;
using PeopleSearchAPI.Models;

namespace PeopleSearchAPI.Tests.Controllers
{
    [TestClass]
    public class PeopleControllerTests
    {
        [TestMethod]
        public void Options_Request_OKResponse()
        {
            // Arrange
            var controller = new PeopleController();

            // Act
            IHttpActionResult result = controller.Options();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ToString().Contains("Ok"));
        }
    }
}
