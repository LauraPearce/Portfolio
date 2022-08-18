using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NailsByNikki.Models
{
    public class BookingHistory
    {
        public int BookingHistoryId { get; set; }
        
        [Required]
        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        [Required]
        public string ServicesCarriedOut { get; set; }





        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
