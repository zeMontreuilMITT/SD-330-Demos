using Microsoft.Extensions.Primitives;

namespace SD_330_Demos.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string VehicleModel { get; set; }
        public DateTime Year { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Vehicle()
        {

        }
    }
}
