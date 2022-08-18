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
    public class BookingControllerUnitTests
    {

        // create mock repository to pass to controller
        private Mock<IBookingRepository> _mockBookingRepository;
        private Mock<IBookingHistoryRepository> _mockBookingHistoryRepository;
        private Mock<IAvailableSlotRepository> _mockAvailableSlotRepository;
        
        [TestInitialize]
        public void Initialise()
        {
            // initialise mock repository to pass to controller
            _mockBookingRepository = new Mock<IBookingRepository>();    
            _mockBookingHistoryRepository = new Mock<IBookingHistoryRepository>();
            _mockAvailableSlotRepository = new Mock<IAvailableSlotRepository>();
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
            BookingController _sut = new BookingController(_mockBookingRepository.Object, _mockBookingHistoryRepository.Object, _mockAvailableSlotRepository.Object);

            // ACT

            IEnumerable<Booking>? response = (_sut.GetAll().Result as OkObjectResult).Value as IEnumerable<Booking>;

            // ASSERT

            // check the values are returned
            Assert.AreEqual(expected.Count(), response.Count());
        }

        [TestMethod]
        public void GetById_Success_ReturnsBookingById()
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
        public void Create_Success_ReturnsNewBooking()
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
        public void Update_Success_ReturnsUpdatedBooking()
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

        [TestMethod]
        public void GetAllBookingsForACustomer_Success_ReturnsAllBookings()
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
        public void GetAllBookingsForACustomer_Failure_ReturnsNotFound()
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
        public void GetAllBookingsBetweenTwoDates_Success_ReturnsAllBookingsBetweenDates()
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
        public void GetAllBookingsBetweenTwoDates_Failure_ReturnsNotFound()
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
        public void CancelBooking_Success_ReturnsOk()
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
        public void CancelBooking_Failure_ReturnsNotFound()
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
        public void MarkBookingAsAttended_Success_ReturnsBookingHistory()
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
        public void MarkBookingAsAttended_Failure_ReturnsNotFound()
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
