using Microsoft.EntityFrameworkCore;
using NailsByNikki.Data;
using NailsByNikki.DTOs;
using NailsByNikki.Models;

namespace NailsByNikki.Repositories
{
    public class AvailableSlotRepository : IAvailableSlotRepository
    {
        private readonly NailsByNikkiDbContext _context;

        public AvailableSlotRepository(NailsByNikkiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AvailableSlot> GetAll()
        {
            return _context.AvailableSlots
                .AsNoTracking()
                .ToList();
        }

        public AvailableSlot? GetById(int id)
        {
            return _context.AvailableSlots
                .AsNoTracking()
                .SingleOrDefault(p => p.AvailableSlotId == id);
        }

        public AvailableSlot Create(AvailableSlot newAvailableSlot)
        {
            _context.AvailableSlots.Add(newAvailableSlot);
            _context.SaveChanges();

            return newAvailableSlot;
        }

        public void Update(AvailableSlot updatedAvailableSlotDetails)
        {
            _context.Update(updatedAvailableSlotDetails);
            _context.SaveChanges();            
        }

        public void Delete(AvailableSlot availableSlotToDelete)
        {
            _context.AvailableSlots.Remove(availableSlotToDelete);
            _context.SaveChanges();
        }
        
        public IEnumerable<AvailableSlot> GetAllFreeSlotsBetweenTwoDates(DateTime startDate, DateTime endDate)
        {
            var query = from a in _context.AvailableSlots.AsNoTracking()
                        join b in _context.Bookings.AsNoTracking()
                            on a.AvailableSlotId equals b.AvailableSlotId
                            into c
                        from b in c.DefaultIfEmpty()
                        where (a.StartDateTime >= startDate && a.StartDateTime <= endDate)
                        && a.StartDateTime > DateTime.Now
                        && b.BookingId == null
                       
                        select new AvailableSlot
                        {
                            AvailableSlotId = a.AvailableSlotId,
                            StartDateTime = a.StartDateTime,
                            EndDateTime = a.EndDateTime
                        };
            return query;
        }


        public void DeleteOldAvailabilitySlots(IEnumerable<AvailableSlot> oldAvailableSlotsToDelete)
        {
            _context.AvailableSlots.RemoveRange(oldAvailableSlotsToDelete);
            _context.SaveChanges();
        }




    }
}
