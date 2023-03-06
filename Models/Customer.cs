namespace SD_330_Demos.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? CompanyName { get; set; }
        public string? Phone { get; set; }
        public virtual HashSet<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
