using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NailsByNikki.Controllers;
using NailsByNikki.Models;
using NailsByNikki.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailsByNikki.Test
{
    [TestClass]

    //TODO: complete test methods
    public class CustomerControllerUnitTests
    {
        // create mock repository to pass to controller
        private Mock<ICustomerRepository> _mockCustomerRepository;

        [TestInitialize]
        public void Initialise()
        {
            // initialise mock repository to pass to controller
            _mockCustomerRepository = new Mock<ICustomerRepository>();
        }

        [TestMethod]
        public void GetAll_Success_ReturnsAllCustomers()
        {
            // ARRANGE
            // create expected return object
           
            Customer customerOne = new Customer
            {
                CustomerId = 0,
                FirstName = "Laura",
                Surname = "Pearce",
                Email = "lauramichellpearce@gmail.com",
                PhoneNumber = "07594682802",
                Allergies = "Caffeine",
                Medication = "None"
            };

            Customer customerTwo = new Customer
            {
                CustomerId = 1,
                FirstName = "Carl",
                Surname = "Pearce",
                Email = "carlpearce201190@gmail.com",
                PhoneNumber = "07713963897",
                Allergies = "None",
                Medication = "None"
            };

            IEnumerable<Customer> expected = new List<Customer> { customerOne, customerTwo };

            // setup mocked repo
            _mockCustomerRepository.Setup(repo => repo.GetAll()).Returns(expected);

            // initialise controller using mocked repository
            CustomerController _sut = new CustomerController(_mockCustomerRepository.Object);

            // ACT
            
            IEnumerable<Customer>? response = (_sut.GetAll().Result as OkObjectResult).Value as IEnumerable<Customer>;

            // ASSERT

            // check the values are returned
            Assert.AreEqual(expected.Count(), response.Count());
        }

        [TestMethod]
        public void GetById_Success_ReturnsCustomerById()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void GetById_Failure_ReturnsNotFound()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void Create_Success_ReturnsNewCustomer()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void Create_Failure_ReturnsBadRequest()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void Update_Success_ReturnsUpdatedCustomer()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void Update_Failure_ReturnsNotFound()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void Delete_Success_ReturnsOk()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void Delete_Failure_ReturnsNotFound()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

    }
}
