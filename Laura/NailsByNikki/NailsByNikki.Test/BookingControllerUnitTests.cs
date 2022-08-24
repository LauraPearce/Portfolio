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
    public class BookingControllerUnitTests
    {

        // create mock repository to pass to controller
        private Mock<IBookingRepository> _mockBookingRepository;
        private Mock<IBookingHistoryRepository> _mockBookingHistoryRepository;
        private Mock<IAvailableSlotRepository> _mockAvailableSlotRepository;
        private Mock<ICustomerRepository> _mockCustomerRepository;
        
        [TestInitialize]
        public void Initialise()
        {
            // initialise mock repository to pass to controller
            _mockBookingRepository = new Mock<IBookingRepository>();    
            _mockBookingHistoryRepository = new Mock<IBookingHistoryRepository>();
            _mockAvailableSlotRepository = new Mock<IAvailableSlotRepository>();
            _mockCustomerRepository = new Mock<ICustomerRepository>();
        }
        [TestMethod]
        public void GetAll_Success_ReturnsAllBookings()
        {
            // ARRANGE
            // create expected return object

            Booking bookingOne = new Booking
            {
                BookingId = 0,
                AvailableSlotId = 0,
                CustomerId = 0
            };

            Booking bookingTwo = new Booking
            {
                BookingId = 1,
                AvailableSlotId = 1,
                CustomerId = 1
            };

            Booking bookingThree = new Booking
            {
                BookingId = 3,
                AvailableSlotId = 3,
                CustomerId = 3
            };
            
            IEnumerable<Booking> expected = new List<Booking> { bookingOne, bookingTwo, bookingThree };

            // setup mocked repo
            _mockBookingRepository.Setup(repo => repo.GetAll()).Returns(expected);

            // initialise controller using mocked repository
            BookingController _sut = new BookingController(_mockBookingRepository.Object, _mockBookingHistoryRepository.Object, _mockAvailableSlotRepository.Object, _mockCustomerRepository.Object);

            // ACT

            IEnumerable<Booking>? response = (_sut.GetAll().Result as OkObjectResult).Value as IEnumerable<Booking>;

            // ASSERT

            // check the values are returned
            Assert.AreEqual(expected.Count(), response.Count());
        }

        [TestMethod]
        public void GetById_Success_ReturnsBookingById()
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
        public void Create_Success_ReturnsNewBooking()
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
        public void Update_Success_ReturnsUpdatedBooking()
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

        [TestMethod]
        public void GetAllBookingsForACustomer_Success_ReturnsAllBookings()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void GetAllBookingsForACustomer_Failure_ReturnsNotFound()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void GetAllBookingsBetweenTwoDates_Success_ReturnsAllBookingsBetweenDates()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void GetAllBookingsBetweenTwoDates_Failure_ReturnsNotFound()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void CancelBooking_Success_ReturnsOk()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void CancelBooking_Failure_ReturnsNotFound()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void MarkBookingAsAttended_Success_ReturnsBookingHistory()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void MarkBookingAsAttended_Failure_ReturnsNotFound()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

    }
}
