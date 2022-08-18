using Microsoft.EntityFrameworkCore;
using NailsByNikki.Data;
using NailsByNikki.DTOs;
using NailsByNikki.Models;
using System.Linq;

namespace NailsByNikki.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly NailsByNikkiDbContext _context;

        public BookingRepository(NailsByNikkiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetAll()
        {
            return _context.Bookings
                .AsNoTracking()
                .ToList();
        }

        public Booking? GetById(int id)
        {
            return _context.Bookings
                .AsNoTracking()
                .SingleOrDefault(p => p.BookingId == id);
        }

       public BookingAvailabilitySlotDto GetDetailsById(int id)
       {
            var query = (from b in _context.Bookings.AsNoTracking()
                         join a in _context.AvailableSlots.AsNoTracking() on b.AvailableSlotId equals a.AvailableSlotId
                         where b.BookingId == id
                         select new BookingAvailabilitySlotDto
                         {
                             BookingId = b.BookingId,
                             CustomerId = b.CustomerId,
                             AvailableSlotId = b.AvailableSlotId,
                             StartDateTime = a.StartDateTime,
                             EndDateTime = a.EndDateTime
                         }).SingleOrDefault();
            return query;
       }

        public Booking Create(Booking newBooking)
        {
            _context.Bookings.Add(newBooking);
            _context.SaveChanges();

            return newBooking;
        }

        public void Update(Booking updatedBookingDetails)
        {
            _context.Bookings.Update(updatedBookingDetails);
            _context.SaveChanges();
        }

        public void Delete(Booking bookingToDelete)
        {            
            _context.Bookings.Remove(bookingToDelete);
            _context.SaveChanges();      
        }

        public IEnumerable<Booking> GetAllBookingsForACustomer(Customer customer)
        {
            return _context.Bookings
                .Where(p => p.CustomerId == customer.CustomerId)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<BookingAvailabilitySlotDto> GetAllBookingsBetweenTwoDates(DateTime startDate, DateTime endDate)
        {
            var query = from b in _context.Bookings.AsNoTracking()
                         join a in _context.AvailableSlots.AsNoTracking() on b.AvailableSlotId equals a.AvailableSlotId
                         where a.StartDateTime.Date >= startDate
                         && a.EndDateTime.Date <= endDate
                         select new BookingAvailabilitySlotDto
                         {
                             BookingId = b.BookingId,
                             CustomerId = b.CustomerId,
                             AvailableSlotId = b.AvailableSlotId,
                             StartDateTime = a.StartDateTime,
                             EndDateTime = a.EndDateTime
                         };
            return query;
        }

   


    }
}
