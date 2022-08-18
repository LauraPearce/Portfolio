using NailsByNikki.Models;

namespace NailsByNikki.Repositories
{
    public interface IBookingHistoryRepository
    {
        IEnumerable<BookingHistory> GetAll();

        BookingHistory? GetById(int id);

        BookingHistory Create(BookingHistory newBookingHistory);

        void Update(BookingHistory updatedBookingHistoryDetails);

        void Delete(BookingHistory bookingHistoryToDelete);

        IEnumerable<BookingHistory> GetAllBookingsHistoryForACustomer(int id);


    }
}
