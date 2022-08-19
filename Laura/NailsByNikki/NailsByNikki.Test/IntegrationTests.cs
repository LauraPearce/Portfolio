using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using NailsByNikki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NailsByNikki.Test
{
    [TestClass]
    public class IntegrationTests
    {
        //TODO: integration test for each type of operation
        [TestMethod]
        public void IntegrationTest()
        {
            // this is doing a complete system test
            // http call > web api > service > database > gets customer > returns it

            // steps below
            // dependency mvc.testing
            // internals visible to clause in main project


            // ARRANGE
            string expected = "Tracey";
            WebApplicationFactory<Program> webApplicationFactory = new WebApplicationFactory<Program>();
            HttpClient client = webApplicationFactory.CreateDefaultClient();



            // ACT
            Customer? actual = client.GetFromJsonAsync<Customer>("/Customer/GetById?id=1").Result;



            // ASSERT

            //check return type
            Assert.IsNotNull(actual);

            //check the values are returned
            Assert.AreEqual(expected, actual.FirstName);
        }
    }
}
