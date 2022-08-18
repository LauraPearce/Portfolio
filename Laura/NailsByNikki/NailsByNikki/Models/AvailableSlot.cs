using System.ComponentModel.DataAnnotations;

namespace NailsByNikki.Models
{
    public class AvailableSlot
    {
        public int AvailableSlotId { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }



        // foreign key hook up for booking class
        public Booking? Booking { get; set; }

    }
}
