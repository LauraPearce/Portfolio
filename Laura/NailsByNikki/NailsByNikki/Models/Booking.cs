using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NailsByNikki.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public bool IsConfirmed { get; set; }

        public DateTime CancellationDate { get; set; }

        public bool CancellationCharge { get; set; }




        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }



        [Required]
        [ForeignKey("AvailableSlot")]
        public int AvailableSlotId { get; set; }
        public AvailableSlot AvailableSlot { get; set; }


    }
}
