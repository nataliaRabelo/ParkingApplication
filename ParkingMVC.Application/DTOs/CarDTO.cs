using System.ComponentModel.DataAnnotations;

namespace ParkingMVC.Application.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }

        [MinLength(6)]
        [MaxLength(6)]
        [Required(ErrorMessage = "Plate is required.")]
        public string Plate { get; set; }

        [MinLength(3)]
        [Required(ErrorMessage = "Color is required.")]
        public string Color { get; set; }

        [MinLength(3)]
        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; }


    }
}
