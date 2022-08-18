using Microsoft.EntityFrameworkCore;
using NailsByNikki.Models;

namespace NailsByNikki.Data
{
    public class NailsByNikkiDbContext : DbContext
    {
        public NailsByNikkiDbContext(DbContextOptions<NailsByNikkiDbContext> options)
                : base(options)
        {
        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<AvailableSlot> AvailableSlots => Set<AvailableSlot>();
        public DbSet<Booking> Bookings =>Set<Booking>();
        public DbSet<BookingHistory> BookingsHistory =>Set<BookingHistory>();
    }
}

