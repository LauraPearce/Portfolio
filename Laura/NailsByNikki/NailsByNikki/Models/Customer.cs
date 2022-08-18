using System.ComponentModel.DataAnnotations;

namespace NailsByNikki.Models
{
    public class Customer
    {

        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Allergies { get; set; }

        [Required]
        public string Medication { get; set; }

        public string AdditionalInformation { get; set; }

        //TODO: check the access of private notes
        public string PrivateNotes { get; set; }




        // foreign key hook ups for booking
        public List<Booking> Bookings { get; set; }

        // foreign key hook ups for booking history
        public List<BookingHistory> BookingsHistory { get; set; }


    }
}
