using Microsoft.EntityFrameworkCore;
using NailsByNikki.Data;
using NailsByNikki.Models;

namespace NailsByNikki.Repositories
{
    public class BookingHistoryRepository : IBookingHistoryRepository
    {
        private readonly NailsByNikkiDbContext _context;

        public BookingHistoryRepository(NailsByNikkiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BookingHistory> GetAll()
        {
            return _context.BookingsHistory
                .AsNoTracking()
                .ToList();
        }

        public BookingHistory? GetById(int id)
        {
            return _context.BookingsHistory
                .AsNoTracking()
                .SingleOrDefault(p => p.BookingHistoryId == id);
        }

        public BookingHistory Create(BookingHistory newBookingHistory)
        {
            _context.BookingsHistory.Add(newBookingHistory);
            _context.SaveChanges();

            return newBookingHistory;
        }

        public void Update(BookingHistory updatedBookingHistoryDetails)
        {
            _context.BookingsHistory.Update(updatedBookingHistoryDetails);
            _context.SaveChanges();
        }

        public void Delete(BookingHistory bookingHistoryToDelete)
        {
            _context.BookingsHistory.Remove(bookingHistoryToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<BookingHistory> GetAllBookingsHistoryForACustomer(int id)
        {
            return _context.BookingsHistory
                .Where(p => p.CustomerId == id)
                .AsNoTracking()
                .ToList();
        }


    }
}
