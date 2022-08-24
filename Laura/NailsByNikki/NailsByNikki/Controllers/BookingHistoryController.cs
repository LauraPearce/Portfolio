using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NailsByNikki.Models;
using NailsByNikki.Repositories;

namespace NailsByNikki.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingHistoryController : ControllerBase
    {
        IBookingHistoryRepository _bookingHistoryRepository;
        ICustomerRepository _customerRepository;
        public BookingHistoryController(IBookingHistoryRepository bookingHistoryRepository, ICustomerRepository customerRepository )
        {
            _bookingHistoryRepository = bookingHistoryRepository;
            _customerRepository = customerRepository;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<BookingHistory>> GetAll()
        {
            return Ok(_bookingHistoryRepository.GetAll());
        }

        [HttpGet("GetById")]
        public ActionResult<BookingHistory> GetById(int id)
        {
            BookingHistory bookingHistory = _bookingHistoryRepository.GetById(id);

            if (bookingHistory is not null)
            {
                return Ok(bookingHistory);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public IActionResult Create(BookingHistory newBookingHistory)
        {
            Customer customer = _customerRepository.GetById(newBookingHistory.CustomerId);

            if (newBookingHistory.StartDateTime != DateTime.MinValue
                && newBookingHistory.EndDateTime != DateTime.MinValue
                && newBookingHistory.ServicesCarriedOut is not null
                && customer is not null)
            {
                _bookingHistoryRepository.Create(newBookingHistory);
                return CreatedAtAction(nameof(Create), new { id = newBookingHistory.BookingHistoryId }, newBookingHistory);
            }
            else
            {
                return BadRequest();
            }            
        }

        [HttpPatch("Update")]
        public IActionResult Update(BookingHistory updatedBookingHistoryDetails)
        {
            BookingHistory bookingHistory = _bookingHistoryRepository.GetById(updatedBookingHistoryDetails.BookingHistoryId);

            if (bookingHistory is not null)
            {
                _bookingHistoryRepository.Update(updatedBookingHistoryDetails);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("Delete")]
        public ActionResult<BookingHistory> Delete(BookingHistory bookingHistoryToDelete)
        {
            BookingHistory bookingHistory = _bookingHistoryRepository.GetById(bookingHistoryToDelete.BookingHistoryId);

            if (bookingHistory is not null)
            {
                _bookingHistoryRepository.Delete(bookingHistoryToDelete);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetAllBookingsHistoryForACustomer")]
        public ActionResult<IEnumerable<BookingHistory>> GetAllBookingsHistoryForACustomer(int id)
        {
            Customer customer = _customerRepository.GetById(id);

            if (customer is not null)
            {
                return Ok(_bookingHistoryRepository.GetAllBookingsHistoryForACustomer(id));
            }
            else
            {
                return NotFound();
            }            
        }






    }
}