namespace NailsByNikki.DTOs
{
    public class BookingAvailabilitySlotDto
    {
        public int BookingId { get; set; }

        public int CustomerId { get; set; }

        public int AvailableSlotId { get; set; }
                
        public DateTime StartDateTime { get; set; }
          
        public DateTime EndDateTime { get; set; }


    }
}
