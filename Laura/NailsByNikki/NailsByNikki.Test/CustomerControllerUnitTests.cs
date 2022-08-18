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
    //TODO: change empty tests to throw not implemented exceptions and remove commented code
    [TestClass]
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
            // ARRANGE

            //// create expected return object

            // setup mocked repo
            //_mockBookingRepository.Setup(repo => repo.GetById(1)).Returns(_expected);

            // initialise controller using mocked repository
            //BookingController _sut = new BookingController(_mockBookingRepository.Object, _mockBookingHistoryRepository.Object, _mockAvailableSlotRepository.Object);

            // ACT

            //ActionResult? response = _sut.GetById(1).Result;


            // ASSERT

            // check the returned status code from the api
            //OkObjectResult httpResult = response as OkObjectResult;
            //Assert.IsNotNull(httpResult);
            //Assert.AreEqual(StatusCodes.Status200OK, httpResult.StatusCode);

            // check return type            
            //Booking booking = httpResult.Value as Booking;
            //Assert.IsNotNull(booking);

            // check the values are returned
            //Assert.AreEqual(_expected.BookingId, booking.BookingId);

            // check the repository method is called once
            //_mockBookingRepository.Verify(repo => repo.GetById(1), Times.Once);
        }

        [TestMethod]
        public void GetById_Failure_ReturnsNotFound()
        {
            // ARRANGE

            //// create expected return object

            // setup mocked repo
            //_mockBookingRepository.Setup(repo => repo.GetById(1)).Returns(_expected);

            // initialise controller using mocked repository
            //BookingController _sut = new BookingController(_mockBookingRepository.Object, _mockBookingHistoryRepository.Object, _mockAvailableSlotRepository.Object);

            // ACT

            //ActionResult? response = _sut.GetById(1).Result;


            // ASSERT

            // check the returned status code from the api
            //OkObjectResult httpResult = response as OkObjectResult;
            //Assert.IsNotNull(httpResult);
            //Assert.AreEqual(StatusCodes.Status200OK, httpResult.StatusCode);

            // check return type            
            //Booking booking = httpResult.Value as Booking;
            //Assert.IsNotNull(booking);

            // check the values are returned
            //Assert.AreEqual(_expected.BookingId, booking.BookingId);

            // check the repository method is called once
            //_mockBookingRepository.Verify(repo => repo.GetById(1), Times.Once);
        }

        [TestMethod]
        public void Create_Success_ReturnsNewCustomer()
        {
            // ARRANGE

            //// create expected return object

            // setup mocked repo
            //_mockBookingRepository.Setup(repo => repo.GetById(1)).Returns(_expected);

            // initialise controller using mocked repository
            //BookingController _sut = new BookingController(_mockBookingRepository.Object, _mockBookingHistoryRepository.Object, _mockAvailableSlotRepository.Object);

            // ACT

            //ActionResult? response = _sut.GetById(1).Result;


            // ASSERT

            // check the returned status code from the api
            //OkObjectResult httpResult = response as OkObjectResult;
            //Assert.IsNotNull(httpResult);
            //Assert.AreEqual(StatusCodes.Status200OK, httpResult.StatusCode);

            // check return type            
            //Booking booking = httpResult.Value as Booking;
            //Assert.IsNotNull(booking);

            // check the values are returned
            //Assert.AreEqual(_expected.BookingId, booking.BookingId);

            // check the repository method is called once
            //_mockBookingRepository.Verify(repo => repo.GetById(1), Times.Once);
        }

        [TestMethod]
        public void Create_Failure_ReturnsBadRequest()
        {
            // ARRANGE

            //// create expected return object

            // setup mocked repo
            //_mockBookingRepository.Setup(repo => repo.GetById(1)).Returns(_expected);

            // initialise controller using mocked repository
            //BookingController _sut = new BookingController(_mockBookingRepository.Object, _mockBookingHistoryRepository.Object, _mockAvailableSlotRepository.Object);

            // ACT

            //ActionResult? response = _sut.GetById(1).Result;


            // ASSERT

            // check the returned status code from the api
            //OkObjectResult httpResult = response as OkObjectResult;
            //Assert.IsNotNull(httpResult);
            //Assert.AreEqual(StatusCodes.Status200OK, httpResult.StatusCode);

            // check return type            
            //Booking booking = httpResult.Value as Booking;
            //Assert.IsNotNull(booking);

            // check the values are returned
            //Assert.AreEqual(_expected.BookingId, booking.BookingId);

            // check the repository method is called once
            //_mockBookingRepository.Verify(repo => repo.GetById(1), Times.Once);
        }

        [TestMethod]
        public void Update_Success_ReturnsUpdatedCustomer()
        {
            // ARRANGE

            //// create expected return object

            // setup mocked repo
            //_mockBookingRepository.Setup(repo => repo.GetById(1)).Returns(_expected);

            // initialise controller using mocked repository
            //BookingController _sut = new BookingController(_mockBookingRepository.Object, _mockBookingHistoryRepository.Object, _mockAvailableSlotRepository.Object);

            // ACT

            //ActionResult? response = _sut.GetById(1).Result;


            // ASSERT

            // check the returned status code from the api
            //OkObjectResult httpResult = response as OkObjectResult;
            //Assert.IsNotNull(httpResult);
            //Assert.AreEqual(StatusCodes.Status200OK, httpResult.StatusCode);

            // check return type            
            //Booking booking = httpResult.Value as Booking;
            //Assert.IsNotNull(booking);

            // check the values are returned
            //Assert.AreEqual(_expected.BookingId, booking.BookingId);

            // check the repository method is called once
            //_mockBookingRepository.Verify(repo => repo.GetById(1), Times.Once);
        }

        [TestMethod]
        public void Update_Failure_ReturnsNotFound()
        {
            // ARRANGE

            //// create expected return object

            // setup mocked repo
            //_mockBookingRepository.Setup(repo => repo.GetById(1)).Returns(_expected);

            // initialise controller using mocked repository
            //BookingController _sut = new BookingController(_mockBookingRepository.Object, _mockBookingHistoryRepository.Object, _mockAvailableSlotRepository.Object);

            // ACT

            //ActionResult? response = _sut.GetById(1).Result;


            // ASSERT

            // check the returned status code from the api
            //OkObjectResult httpResult = response as OkObjectResult;
            //Assert.IsNotNull(httpResult);
            //Assert.AreEqual(StatusCodes.Status200OK, httpResult.StatusCode);

            // check return type            
            //Booking booking = httpResult.Value as Booking;
            //Assert.IsNotNull(booking);

            // check the values are returned
            //Assert.AreEqual(_expected.BookingId, booking.BookingId);

            // check the repository method is called once
            //_mockBookingRepository.Verify(repo => repo.GetById(1), Times.Once);
        }

        [TestMethod]
        public void Delete_Success_ReturnsOk()
        {
            // ARRANGE

            //// create expected return object

            // setup mocked repo
            //_mockBookingRepository.Setup(repo => repo.GetById(1)).Returns(_expected);

            // initialise controller using mocked repository
            //BookingController _sut = new BookingController(_mockBookingRepository.Object, _mockBookingHistoryRepository.Object, _mockAvailableSlotRepository.Object);

            // ACT

            //ActionResult? response = _sut.GetById(1).Result;


            // ASSERT

            // check the returned status code from the api
            //OkObjectResult httpResult = response as OkObjectResult;
            //Assert.IsNotNull(httpResult);
            //Assert.AreEqual(StatusCodes.Status200OK, httpResult.StatusCode);

            // check return type            
            //Booking booking = httpResult.Value as Booking;
            //Assert.IsNotNull(booking);

            // check the values are returned
            //Assert.AreEqual(_expected.BookingId, booking.BookingId);

            // check the repository method is called once
            //_mockBookingRepository.Verify(repo => repo.GetById(1), Times.Once);
        }

        [TestMethod]
        public void Delete_Failure_ReturnsNotFound()
        {
            // ARRANGE

            //// create expected return object

            // setup mocked repo
            //_mockBookingRepository.Setup(repo => repo.GetById(1)).Returns(_expected);

            // initialise controller using mocked repository
            //BookingController _sut = new BookingController(_mockBookingRepository.Object, _mockBookingHistoryRepository.Object, _mockAvailableSlotRepository.Object);

            // ACT

            //ActionResult? response = _sut.GetById(1).Result;


            // ASSERT

            // check the returned status code from the api
            //OkObjectResult httpResult = response as OkObjectResult;
            //Assert.IsNotNull(httpResult);
            //Assert.AreEqual(StatusCodes.Status200OK, httpResult.StatusCode);

            // check return type            
            //Booking booking = httpResult.Value as Booking;
            //Assert.IsNotNull(booking);

            // check the values are returned
            //Assert.AreEqual(_expected.BookingId, booking.BookingId);

            // check the repository method is called once
            //_mockBookingRepository.Verify(repo => repo.GetById(1), Times.Once);
        }

    }
}
