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
    public class BookingHistoryControllerUnitTests
    {
        // create mock repository to pass to controller
        private Mock<IBookingHistoryRepository> _mockBookingHistoryRepository;
        private Mock<ICustomerRepository> _mockCustomerRepository;
        
        [TestInitialize]
        public void Initialise()
        {
            // initialise mock repository to pass to controller
            _mockBookingHistoryRepository = new Mock<IBookingHistoryRepository>();
            _mockCustomerRepository = new Mock<ICustomerRepository>();
        }

        [TestMethod]
        public void GetAll_Success_ReturnsAllBookingsHistory()
        {
            // ARRANGE
            // create expected return object

            BookingHistory bookingHistoryOne = new BookingHistory
            {
                BookingHistoryId = 0,
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                ServicesCarriedOut = "Nails",
                CustomerId = 1
            };

            BookingHistory bookingHistoryTwo = new BookingHistory
            {
                BookingHistoryId = 1,
                StartDateTime = new DateTime(2022, 09, 11, 15, 00, 00),
                ServicesCarriedOut = "Nails and toes",
                CustomerId = 3
            };

            BookingHistory bookingHistoryThree = new BookingHistory
            {
                BookingHistoryId = 2,
                StartDateTime = new DateTime(2022, 09, 15, 15, 00, 00),
                ServicesCarriedOut = "Nails and gels",
                CustomerId = 2
            };
            IEnumerable<BookingHistory> expected = new List<BookingHistory> { bookingHistoryOne, bookingHistoryTwo, bookingHistoryThree };

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.GetAll()).Returns(expected);

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            ActionResult? response = _sut.GetAll().Result;



            // ASSERT

            // check the values are returned
            OkObjectResult httpResult = response as OkObjectResult;
            IEnumerable<BookingHistory> bookingsHistory = (httpResult.Value) as IEnumerable<BookingHistory>;
            
            Assert.AreEqual(expected, bookingsHistory);
        }

        [TestMethod]
        public void GetById_Success_ChecksStatusCode()
        {
            // ARRANGE
            // create expected return object

            BookingHistory bookingHistoryOne = new BookingHistory
            {
                BookingHistoryId = 0,
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                ServicesCarriedOut = "Nails",
                CustomerId = 1
            };

            BookingHistory bookingHistoryTwo = new BookingHistory
            {
                BookingHistoryId = 1,
                StartDateTime = new DateTime(2022, 09, 11, 15, 00, 00),
                ServicesCarriedOut = "Nails and toes",
                CustomerId = 3
            };

            BookingHistory bookingHistoryThree = new BookingHistory
            {
                BookingHistoryId = 2,
                StartDateTime = new DateTime(2022, 09, 15, 15, 00, 00),
                ServicesCarriedOut = "Nails and gels",
                CustomerId = 2
            };
            
            BookingHistory expected = bookingHistoryThree;

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.GetById(2)).Returns(expected);

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);

           
            
            // ACT

            ActionResult? response = _sut.GetById(2).Result;



            // ASSERT

            // check the returned status code from the api
            OkObjectResult httpResult = response as OkObjectResult;
            Assert.IsNotNull(httpResult);
            Assert.AreEqual(StatusCodes.Status200OK, httpResult.StatusCode);       
        }

        [TestMethod]
        public void GetById_Success_ChecksForNotNullResponse()
        {
            // ARRANGE
            // create expected return object

            BookingHistory bookingHistoryOne = new BookingHistory
            {
                BookingHistoryId = 0,
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                ServicesCarriedOut = "Nails",
                CustomerId = 1
            };

            BookingHistory bookingHistoryTwo = new BookingHistory
            {
                BookingHistoryId = 1,
                StartDateTime = new DateTime(2022, 09, 11, 15, 00, 00),
                ServicesCarriedOut = "Nails and toes",
                CustomerId = 3
            };

            BookingHistory bookingHistoryThree = new BookingHistory
            {
                BookingHistoryId = 2,
                StartDateTime = new DateTime(2022, 09, 15, 15, 00, 00),
                ServicesCarriedOut = "Nails and gels",
                CustomerId = 2
            };

            BookingHistory expected = bookingHistoryThree;

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.GetById(2)).Returns(expected);

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            ActionResult? response = _sut.GetById(2).Result;



            // ASSERT

            // check return type
            OkObjectResult httpResult = response as OkObjectResult;
            BookingHistory bookingHistory = httpResult.Value as BookingHistory;
            Assert.IsNotNull(bookingHistory);
        }

        [TestMethod]
        public void GetById_Success_ReturnsBookingHistoryId()
        {
            // ARRANGE
            // create expected return object

            BookingHistory bookingHistoryOne = new BookingHistory
            {
                BookingHistoryId = 0,
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                ServicesCarriedOut = "Nails",
                CustomerId = 1
            };

            BookingHistory bookingHistoryTwo = new BookingHistory
            {
                BookingHistoryId = 1,
                StartDateTime = new DateTime(2022, 09, 11, 15, 00, 00),
                ServicesCarriedOut = "Nails and toes",
                CustomerId = 3
            };

            BookingHistory bookingHistoryThree = new BookingHistory
            {
                BookingHistoryId = 2,
                StartDateTime = new DateTime(2022, 09, 15, 15, 00, 00),
                ServicesCarriedOut = "Nails and gels",
                CustomerId = 2
            };

            BookingHistory expected = bookingHistoryThree;

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.GetById(2)).Returns(expected);

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            ActionResult? response = _sut.GetById(2).Result;



            // ASSERT

            // check return type
            OkObjectResult httpResult = response as OkObjectResult;
            BookingHistory bookingHistory = httpResult.Value as BookingHistory;

            // check the values are returned
            Assert.AreEqual(expected.BookingHistoryId, bookingHistory.BookingHistoryId);
        }

        [TestMethod]
        public void GetById_Success_ChecksRepositoryMethodIsCalledOnce()
        {
            // ARRANGE
            // create expected return object

            BookingHistory bookingHistoryOne = new BookingHistory
            {
                BookingHistoryId = 0,
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                ServicesCarriedOut = "Nails",
                CustomerId = 1
            };

            BookingHistory bookingHistoryTwo = new BookingHistory
            {
                BookingHistoryId = 1,
                StartDateTime = new DateTime(2022, 09, 11, 15, 00, 00),
                ServicesCarriedOut = "Nails and toes",
                CustomerId = 3
            };

            BookingHistory bookingHistoryThree = new BookingHistory
            {
                BookingHistoryId = 2,
                StartDateTime = new DateTime(2022, 09, 15, 15, 00, 00),
                ServicesCarriedOut = "Nails and gels",
                CustomerId = 2
            };

            BookingHistory expected = bookingHistoryThree;

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.GetById(2)).Returns(expected);

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            ActionResult? response = _sut.GetById(2).Result;



            // ASSERT

            // check the repository method is called once
            _mockBookingHistoryRepository.Verify(repo => repo.GetById(2), Times.Once);

        }
      
        [TestMethod]
        public void GetById_Failure_ReturnsNotFound()
        {
            // ARRANGE
            // create expected return object

            BookingHistory bookingHistoryOne = new BookingHistory
            {
                BookingHistoryId = 0,
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                ServicesCarriedOut = "Nails",
                CustomerId = 1
            };

            BookingHistory bookingHistoryTwo = new BookingHistory
            {
                BookingHistoryId = 1,
                StartDateTime = new DateTime(2022, 09, 11, 15, 00, 00),
                ServicesCarriedOut = "Nails and toes",
                CustomerId = 3
            };

            BookingHistory bookingHistoryThree = new BookingHistory
            {
                BookingHistoryId = 2,
                StartDateTime = new DateTime(2022, 09, 15, 15, 00, 00),
                ServicesCarriedOut = "Nails and gels",
                CustomerId = 2
            };

            BookingHistory expected = bookingHistoryThree;

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.GetById(2)).Returns(expected);

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            ActionResult? response = _sut.GetById(3).Result;



            // ASSERT

            // check the returned status code from the api
            NotFoundResult httpResult = response as NotFoundResult;         
            Assert.AreEqual(StatusCodes.Status404NotFound, httpResult.StatusCode);
        }

        [TestMethod]
        public void Create_Success_ChecksStatusCode()
        {
            // ARRANGE
            // create expected return object

            BookingHistory bookingHistoryOne = new BookingHistory
            {
                BookingHistoryId = 0,
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                EndDateTime = new DateTime(2022, 09, 18, 17, 00, 00),
                ServicesCarriedOut = "Nails",
                CustomerId = 1
            };

            BookingHistory expected = bookingHistoryOne;

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.Create(bookingHistoryOne)).Returns(expected);

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            IActionResult? response = _sut.Create(bookingHistoryOne);



            // ASSERT

            // check the returned status code from the api
            CreatedAtActionResult httpResult = response as CreatedAtActionResult;
            Assert.AreEqual(StatusCodes.Status201Created, httpResult.StatusCode);
        }

        [TestMethod]
        public void Create_Success_ChecksForNotNullResponse()
        {
            // ARRANGE
            // create expected return object

            BookingHistory bookingHistoryOne = new BookingHistory
            {
                BookingHistoryId = 0,
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                EndDateTime =new DateTime(2022, 09, 18, 15, 00, 00),
                ServicesCarriedOut = "Nails",
                CustomerId = 1
            };

            BookingHistory expected = bookingHistoryOne;

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.Create(bookingHistoryOne)).Returns(expected);

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            IActionResult? response = _sut.Create(bookingHistoryOne);



            // ASSERT

            // check return type
            CreatedAtActionResult httpResult = response as CreatedAtActionResult;
            BookingHistory bookingHistory = httpResult.Value as BookingHistory;
            Assert.IsNotNull(bookingHistory);
        }

        [TestMethod]
        public void Create_Success_ReturnsBookingHistoryId()
        {
            // ARRANGE
            // create expected return object

            BookingHistory bookingHistoryOne = new BookingHistory
            {
                BookingHistoryId = 0,
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                EndDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                ServicesCarriedOut = "Nails",
                CustomerId = 1
            };

            BookingHistory expected = bookingHistoryOne;

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.Create(bookingHistoryOne)).Returns(expected);

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            IActionResult? response = _sut.Create(bookingHistoryOne);



            // ASSERT

            // check return type
            CreatedAtActionResult httpResult = response as CreatedAtActionResult;
            BookingHistory bookingHistory = httpResult.Value as BookingHistory;

            // check the values are returned
            Assert.AreEqual(expected.BookingHistoryId, bookingHistory.BookingHistoryId);
        }

        [TestMethod]
        public void Create_Success_ChecksRepositoryMethodIsCalledOnce()
        {
            // ARRANGE
            // create expected return object

            BookingHistory expected = new BookingHistory
            {                
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                EndDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                ServicesCarriedOut = "Nails",
                CustomerId = 1
            };
                      

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.Create(expected)).Returns(expected);

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            IActionResult? response = _sut.Create(expected);


            
            // ASSERT

            // check the repository method is called once
            _mockBookingHistoryRepository.Verify(repo => repo.Create(expected), Times.Once);
        }

        [TestMethod]
        public void Create_Failure_ReturnsBadRequest()
        {
            // ARRANGE
            // create expected return object

            BookingHistory expected = new BookingHistory
            {
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                CustomerId = 1
            };

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.Create(expected)).Returns(expected);

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            IActionResult? response = _sut.Create(expected);



            // ASSERT

            // check the returned status code from the api
            BadRequestResult httpResult = response as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, httpResult.StatusCode);
        }

        [TestMethod]
        public void Update_Success_ReturnsOkActionResult()
        {
            // ARRANGE
            // create expected return object
            BookingHistory getBookingHistory = new BookingHistory
            {
                BookingHistoryId = 1,
                StartDateTime = new DateTime(2022, 09, 20, 15, 00, 00),
                EndDateTime = new DateTime(2022, 09, 20, 17, 00, 00),
                ServicesCarriedOut = "Nails and toes",
                CustomerId = 1
            };

            BookingHistory updatedBookingHistory = new BookingHistory
            {
                BookingHistoryId = 1,
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                EndDateTime = new DateTime(2022, 09, 18, 17, 00, 00),
                ServicesCarriedOut = "Nails",
                CustomerId = 1
            };

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.GetById(getBookingHistory.BookingHistoryId)).Returns(getBookingHistory);
            _mockBookingHistoryRepository.Setup(repo => repo.Update(updatedBookingHistory));

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            IActionResult? response = _sut.Update(updatedBookingHistory);



            // ASSERT

            // check return type
            OkResult httpResult = response as OkResult;
            Assert.AreEqual(StatusCodes.Status200OK, httpResult.StatusCode);            
        }
               
        [TestMethod]
        public void Update_Failure_ReturnsNotFound()
        {
            // ARRANGE
            // create expected return object
            BookingHistory getBookingHistory = new BookingHistory
            {
                BookingHistoryId = 1,
                StartDateTime = new DateTime(2022, 09, 20, 15, 00, 00),
                EndDateTime = new DateTime(2022, 09, 20, 17, 00, 00),
                ServicesCarriedOut = "Nails and toes",
                CustomerId = 1
            };

            BookingHistory updatedBookingHistory = new BookingHistory
            {
                BookingHistoryId = 2,
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                EndDateTime = new DateTime(2022, 09, 18, 17, 00, 00),
                ServicesCarriedOut = "Nails",
                CustomerId = 1
            };

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.GetById(getBookingHistory.BookingHistoryId)).Returns(getBookingHistory);
            _mockBookingHistoryRepository.Setup(repo => repo.Update(updatedBookingHistory));

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            IActionResult? response = _sut.Update(updatedBookingHistory);



            // ASSERT

            // check return type
            NotFoundResult httpResult = response as NotFoundResult;
            Assert.AreEqual(StatusCodes.Status404NotFound, httpResult.StatusCode);
        }

        [TestMethod]
        public void Delete_Success_ReturnsOk()
        {
            // ARRANGE
            // create expected return object
            BookingHistory getBookingHistory = new BookingHistory
            {
                BookingHistoryId = 1,
                StartDateTime = new DateTime(2022, 09, 20, 15, 00, 00),
                EndDateTime = new DateTime(2022, 09, 20, 17, 00, 00),
                ServicesCarriedOut = "Nails and toes",
                CustomerId = 1
            };

            BookingHistory bookingHistoryToBeDeleted = new BookingHistory
            {
                BookingHistoryId = 1,
            };

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.GetById(getBookingHistory.BookingHistoryId)).Returns(getBookingHistory);
            _mockBookingHistoryRepository.Setup(repo => repo.Delete(bookingHistoryToBeDeleted));

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            ActionResult? response = _sut.Delete(bookingHistoryToBeDeleted).Result;



            // ASSERT

            // check return type
            OkResult httpResult = response as OkResult;
            Assert.AreEqual(StatusCodes.Status200OK, httpResult.StatusCode); 
        }

        [TestMethod]
        public void Delete_Failure_ReturnsNotFound()
        {
            // ARRANGE
            // create expected return object
            BookingHistory getBookingHistory = new BookingHistory
            {
                BookingHistoryId = 1,
                StartDateTime = new DateTime(2022, 09, 20, 15, 00, 00),
                EndDateTime = new DateTime(2022, 09, 20, 17, 00, 00),
                ServicesCarriedOut = "Nails and toes",
                CustomerId = 1
            };

            BookingHistory bookingHistoryToBeDeleted = new BookingHistory
            {
                BookingHistoryId = 3,
            };

            // setup mocked repo
            _mockBookingHistoryRepository.Setup(repo => repo.GetById(getBookingHistory.BookingHistoryId)).Returns(getBookingHistory);
            _mockBookingHistoryRepository.Setup(repo => repo.Delete(bookingHistoryToBeDeleted));

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            ActionResult? response = _sut.Delete(bookingHistoryToBeDeleted).Result;



            // ASSERT

            // check return type
            NotFoundResult httpResult = response as NotFoundResult;
            Assert.AreEqual(StatusCodes.Status404NotFound, httpResult.StatusCode);
        }

        [TestMethod]
        public void GetAllBookingsHistoryForACustomer_Success_ReturnsBookingsHistory()
        {
            // ARRANGE
            // create expected return object

            BookingHistory bookingHistoryOne = new BookingHistory
            {
                BookingHistoryId = 0,
                StartDateTime = new DateTime(2022, 09, 18, 15, 00, 00),
                ServicesCarriedOut = "Nails",
                CustomerId = 1
            };

            BookingHistory bookingHistoryTwo = new BookingHistory
            {
                BookingHistoryId = 1,
                StartDateTime = new DateTime(2022, 09, 11, 15, 00, 00),
                ServicesCarriedOut = "Nails and toes",
                CustomerId = 1
            };

            BookingHistory bookingHistoryThree = new BookingHistory
            {
                BookingHistoryId = 2,
                StartDateTime = new DateTime(2022, 09, 15, 15, 00, 00),
                ServicesCarriedOut = "Nails and gels",
                CustomerId = 2
            };

            Customer customer = new Customer
            {
                CustomerId = 1,
                FirstName = "Carl",
                Surname = "Pearce",
                Email = "carlpearce201190@gmail.com",
                PhoneNumber = "07713 963897",
                Allergies = "None",
                Medication = "None"
            };

            IEnumerable<BookingHistory> expected = new List<BookingHistory> { bookingHistoryOne, bookingHistoryTwo };

            // setup mocked repo
            _mockCustomerRepository.Setup(repo => repo.GetById(1)).Returns(customer);
            _mockBookingHistoryRepository.Setup(repo => repo.GetAllBookingsHistoryForACustomer(1)).Returns(expected);

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            ActionResult response = _sut.GetAllBookingsHistoryForACustomer(1).Result;



            // ASSERT

            // check the values are returned
            OkObjectResult httpResult = response as OkObjectResult;
            IEnumerable<BookingHistory> bookingsHistory = (httpResult.Value) as IEnumerable<BookingHistory>;

            Assert.AreEqual(expected, bookingsHistory);
        }

        [TestMethod]
        public void GetAllBookingsForACustomer_Failure_ReturnsNotFound()
        {
            // ARRANGE
            
            // setup mocked repo
            _mockCustomerRepository.Setup(repo => repo.GetById(4));           

            // initialise controller using mocked repository
            BookingHistoryController _sut = new BookingHistoryController(_mockBookingHistoryRepository.Object, _mockCustomerRepository.Object);



            // ACT

            ActionResult response = _sut.GetAllBookingsHistoryForACustomer(4).Result;
            


            // ASSERT

            // check the values are returned
            NotFoundResult httpResult = response as NotFoundResult;
            Assert.AreEqual(StatusCodes.Status404NotFound, httpResult.StatusCode);
        }

    }
}
