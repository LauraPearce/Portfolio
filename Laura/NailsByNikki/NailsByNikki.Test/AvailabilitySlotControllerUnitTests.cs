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
    public class AvailabilitySlotControllerUnitTests
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
        public void GetAll_Success_ReturnsAllAvailableSlots()
        {
            // ARRANGE
            // create expected return object

            AvailableSlot availableSlotOne = new AvailableSlot
            {
                AvailableSlotId = 0,
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                EndDateTime = new DateTime(2022, 09, 18, 17, 00, 00)
            };

            AvailableSlot availableSlotTwo = new AvailableSlot
            {
                AvailableSlotId = 1,
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                EndDateTime = new DateTime(2022, 09, 18, 17, 00, 00)
            };

            IEnumerable<AvailableSlot> expected = new List<AvailableSlot> { availableSlotOne, availableSlotTwo };

            // setup mocked repo
            _mockAvailableSlotRepository.Setup(repo => repo.GetAll()).Returns(expected);

            // initialise controller using mocked repository
            AvailableSlotController _sut = new AvailableSlotController(_mockAvailableSlotRepository.Object);

            // ACT

            IEnumerable<AvailableSlot>? response = (_sut.GetAll().Result as OkObjectResult).Value as IEnumerable<AvailableSlot>;

            // ASSERT

            // check the values are returned
            Assert.AreEqual(expected.Count(), response.Count());
        }

        [TestMethod]
        public void GetById_Success_ReturnsAvailableSlotById()
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
        public void Create_Success_ReturnsNewAvailableSlot()
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
        public void Update_Success_ReturnsUpdatedAvailableSlot()
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
        public void GetAllFreeSlotsBetweenTwoDates_Success_ReturnsDates()
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
        public void GetAllFreeSlotsBetweenTwoDates_Failure_ReturnsNotFound()
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
        public void DeleteOldAvailabilitySlots_Success_ReturnsOk()
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
        public void DeleteOldAvailabilitySlots_Failure_ReturnsNotFound()
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
