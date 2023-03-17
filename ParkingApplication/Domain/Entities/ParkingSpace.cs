using ParkingApplication.Domain.Validation;

namespace ParkingApplication.Domain.Entities
{
    public class ParkingSpace : EntityBase
    {

        public int IdCar { get; private set; }

        public Car Car { get; private set; }



        public void SetIdCar(int id)
        {
            ValidateDomain(id);
            IdCar = id;
        }

        private void ValidateDomain(int id)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(id.ToString()), "Car id is required.");

        }

    }
}
