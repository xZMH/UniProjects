using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _77CarRental.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
       
        [Required]
        public int? CustomerId { get; set; }

        [Required]
        public int? CarId { get; set; }


        [Required]
        public DateTime Start_Date { get; set; }

        [Required]
        public DateTime End_Date { get; set; }

        public string? ReservationStatus { get; set; }



        public Customer? Customer { get; set; }
        public Car? Car { get; set; }
    }


}
