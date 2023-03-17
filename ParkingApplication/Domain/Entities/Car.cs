using ParkingApplication.Domain.Validation;

namespace ParkingApplication.Domain.Entities
{
    public class Car : EntityBase
    {

        public string Plate { get; private set; }

        public string Color { get; private set; }

        public string Model { get; private set; }


        public Car(string plate, string color, string model)
        {
            ValidateDomain(plate, color, model);
            Plate = plate;
            Color = color;
            Model = model;
        }

        private void ValidateDomain(string plate, string color, string model)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(plate), "Plate is required");
            DomainExceptionValidation.When(plate.Length != 6, "Invalid plate. A plate must contain 6 digits");
            DomainExceptionValidation.When(string.IsNullOrEmpty(color), "Color is required");
            DomainExceptionValidation.When(color.Length < 3, "Invalid color. Too short, the color must have minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(model), "Model is required");
            DomainExceptionValidation.When(color.Length < 3, "Invalid model. Too short, the model must have minimum 3 characters");
        }
    }
}
