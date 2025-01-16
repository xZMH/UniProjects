using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _77CarRental.Models
{
    public class Car
    {
        [Key]
        [Required]
        public int CarId { get; set; }
        [Required]
        [StringLength(50)]
        public string? Make {  get; set; }
       
        [Required]
        [StringLength(50)]
        public string? Model {  get; set; }
        [Required]
        [Range(1900,2100)]
        public int Year { get; set; }
        
        public string? Color { get; set; }

        [Required]
        [Range(100,1000)]
        public double Price { get; set; }

        public string? CarStatus {  get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [StringLength(100)]
        public string? ImagePath { get; set; }
    }
}
