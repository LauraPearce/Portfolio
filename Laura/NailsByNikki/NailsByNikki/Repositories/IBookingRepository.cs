using NailsByNikki.DTOs;
using NailsByNikki.Models;

namespace NailsByNikki.Repositories
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAll();

        Booking? GetById(int id);

        Booking Create(Booking newBooking);

        void Update(Booking updatedBookingDetails);

        void Delete(Booking bookingToDelete);

        IEnumerable<Booking> GetAllBookingsForACustomer(Customer customer);

        IEnumerable<BookingAvailabilitySlotDto> GetAllBookingsBetweenTwoDates(DateTime startDate, DateTime endDate);

        BookingAvailabilitySlotDto GetDetailsById(int id);

    }
}
