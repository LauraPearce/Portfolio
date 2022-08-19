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
        public void Create_Success_ReturnsNewAvailableSlot()
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
        public void Update_Success_ReturnsUpdatedAvailableSlot()
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
        public void GetAllFreeSlotsBetweenTwoDates_Success_ReturnsDates()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void GetAllFreeSlotsBetweenTwoDates_Failure_ReturnsNotFound()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void DeleteOldAvailabilitySlots_Success_ReturnsOk()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

        [TestMethod]
        public void DeleteOldAvailabilitySlots_Failure_ReturnsNotFound()
        {
            throw new NotImplementedException();

            // ARRANGE

            // ACT            

            // ASSERT
        }

    }
}
