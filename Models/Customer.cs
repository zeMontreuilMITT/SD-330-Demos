using System.ComponentModel.DataAnnotations;

namespace SD_330_Demos.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public HashSet<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();

        public Customer() { }
    }
}
