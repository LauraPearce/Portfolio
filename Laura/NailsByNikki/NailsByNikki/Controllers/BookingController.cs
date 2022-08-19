using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NailsByNikki.DTOs;
using NailsByNikki.Models;
using NailsByNikki.Repositories;

namespace NailsByNikki.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        IBookingRepository _bookingRepository;
        IBookingHistoryRepository _bookingHistoryRepository;
        IAvailableSlotRepository _availableSlotRepository;
        ICustomerRepository _customerRepository;
        public BookingController(IBookingRepository bookingRepository, IBookingHistoryRepository bookingHistoryRepository, IAvailableSlotRepository availableSlotRepository, ICustomerRepository customerRepository)
        {
            _bookingRepository = bookingRepository;
            _bookingHistoryRepository = bookingHistoryRepository;
            _availableSlotRepository = availableSlotRepository;
            _customerRepository = customerRepository;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Booking>> GetAll()
        {
            return Ok(_bookingRepository.GetAll());
        }

        [HttpGet("GetById")]
        public ActionResult<Booking> GetById(int id)
        {
            Booking booking = _bookingRepository.GetById(id);

            if (booking is not null)
            {
                return Ok(booking);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public IActionResult Create(int customerId, int availabilitySlotId)
        {
            Booking newBooking = new Booking
            {
                CustomerId = customerId,
                AvailableSlotId = availabilitySlotId
            };

            Customer customer = _customerRepository.GetById(customerId);

            //TODO: finish validation to check if the availableSlotId and customerId are correct (i.e, availableslot is available)
            if (newBooking.CustomerId >= 0
                && newBooking.AvailableSlotId >= 0)
            {
                _bookingRepository.Create(newBooking);
                return CreatedAtAction(nameof(Create), new { id = newBooking.BookingId }, newBooking);
            }
            else
            {
                return BadRequest();
            }               
        }

        [HttpPatch("Update")]
        public IActionResult Update(Booking updatedBookingDetails)
        {
            Booking booking = _bookingRepository.GetById(updatedBookingDetails.BookingId);

            if (booking is not null)
            {
                _bookingRepository.Update(updatedBookingDetails);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Booking bookingToDelete)
        {
            Booking booking = _bookingRepository.GetById(bookingToDelete.BookingId);

            if (booking is not null)
            {
                _bookingRepository.Delete(bookingToDelete);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetAllBookingsForACustomer")]
        public ActionResult<IEnumerable<Booking>> GetAllBookingsForACustomer([FromQuery]Customer customer)
        {
            IEnumerable<Booking> bookings = _bookingRepository.GetAllBookingsForACustomer(customer);

            if (bookings is not null)
            {
                return Ok(bookings);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetAllBookingsBetweenTwoDates")]
        public ActionResult<IEnumerable<BookingAvailabilitySlotDto>> GetAllBookingsBetweenTwoDates(DateTime startDate, DateTime endDate)
        {
            IEnumerable<BookingAvailabilitySlotDto> bookings = _bookingRepository.GetAllBookingsBetweenTwoDates(startDate, endDate);

            if (bookings is not null)
            {
                return Ok(bookings);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("CancelBooking")]
        public IActionResult CancelBooking(int id)
        {
            Booking bookingToCancel = _bookingRepository.GetById(id);
            AvailableSlot availabilitySlotOfBookingToCancel = _availableSlotRepository.GetById(bookingToCancel.AvailableSlotId);

            if (bookingToCancel is not null && availabilitySlotOfBookingToCancel is not null)
            {
                bookingToCancel.IsConfirmed = false;
                bookingToCancel.CancellationDate = DateTime.Now;

                if (bookingToCancel.CancellationDate > availabilitySlotOfBookingToCancel.StartDateTime.AddDays(-2))
                {
                    bookingToCancel.CancellationCharge = true;
                }

                _bookingRepository.Update(bookingToCancel);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("MarkBookingAsAttended")]
        public ActionResult<BookingHistory> MarkBookingAsAttended(int id, string servicesCarriedOut)
        {
            // finds the booking and availability slot details
            BookingAvailabilitySlotDto bookingDetails = _bookingRepository.GetDetailsById(id);
            Booking bookingToDelete = _bookingRepository.GetById(id);             
            AvailableSlot availableSlotToDelete = _availableSlotRepository.GetById(bookingToDelete.AvailableSlotId);
            
            // checks the booking and details have been found before creating booking history
            if (bookingDetails is not null && bookingToDelete is not null && availableSlotToDelete is not null)
            {
                BookingHistory bookingHistory = new BookingHistory 
                {
                    StartDateTime = bookingDetails.StartDateTime,
                    EndDateTime = bookingDetails.EndDateTime,
                    CustomerId = bookingDetails.CustomerId,
                    ServicesCarriedOut = servicesCarriedOut
                };                           
                
                // creates the booking history and saves to the database
                _bookingHistoryRepository.Create(bookingHistory);

                // deletes the booking and availability slot
                _bookingRepository.Delete(bookingToDelete);
                _availableSlotRepository.Delete(availableSlotToDelete);

                return Ok(bookingHistory);
            }
            else
            {
                // if booking and details cannot be found, returns not found
                return NotFound();
            }
            

        }




    }
}