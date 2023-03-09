namespace SD_330_Demos.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string? Phone { get; set; }
        public virtual HashSet<CustomerAddress> CustomerAddresses{ get; set; } = new HashSet<CustomerAddress>();

        public Customer()
        {

        }

        public Customer(string firstName, string lastName, string companyName, string? phone)
        {
            FirstName = firstName;
            LastName = lastName;
            CompanyName = companyName;
            Phone = phone;
        }
    }
}
