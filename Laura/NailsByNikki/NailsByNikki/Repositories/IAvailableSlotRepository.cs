using NailsByNikki.Models;

namespace NailsByNikki.Repositories
{
    public interface IAvailableSlotRepository
    {
        IEnumerable<AvailableSlot> GetAll();

        AvailableSlot? GetById(int id);

        AvailableSlot Create(AvailableSlot newAvailableSlot);

        void Update(AvailableSlot updatedAvailableSlotDetails);

        void Delete(AvailableSlot availableSlotToDelete);

        IEnumerable<AvailableSlot> GetAllFreeSlotsBetweenTwoDates(DateTime startDate, DateTime endDate);

        void DeleteOldAvailabilitySlots(IEnumerable<AvailableSlot> oldAvailableSlotsToDelete);

    }
}
