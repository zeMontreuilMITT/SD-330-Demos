namespace SD_330_Demos.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }   
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }
        public virtual HashSet<CustomerAddress> CustomerAddresses { get; set; } = new HashSet<CustomerAddress>();

        public Address(string line1, string? line2, string city, string stateProvice, string countryRegion)
        {
            AddressLine1 = line1;
            AddressLine2 = line2;
            City = city;
            StateProvince = stateProvice;
            CountryRegion = countryRegion;
        }

        public Address()
        {

        }
    }
}
