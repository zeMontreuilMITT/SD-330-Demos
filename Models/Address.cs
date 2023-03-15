using System.ComponentModel.DataAnnotations;

namespace SD_330_Demos.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "Must be between 3 and 200 characters in length", MinimumLength = 3)]
        [Display(Name ="Address Line 1")]
        public string AddressLine1 { get; set; }


        [StringLength(200, ErrorMessage = "Maximum 200 characters in length")]
        [Display(Name ="Address Line 2")]
        public string? AddressLine2 { get; set; }


        [Required(AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "Must be between 3 and 200 characters in length", MinimumLength = 3)]
        public string City { get; set; }


        [Required(AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "Must be between 3 and 200 characters in length", MinimumLength = 3)]
        [Display(Name ="State/Province")]
        public string StateProvince { get; set; }



        [Required(AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "Must be between 3 and 200 characters in length", MinimumLength = 3)]
        [Display(Name = "Country/Region")]
        public string CountryRegion { get; set; }


        public virtual HashSet<CustomerAddress> CustomerAddresses { get; set; } = new HashSet<CustomerAddress>();

        public Address() { }

        public Address(string line1, string? line2, string city, string state, string country)
        {
            AddressLine1 = line1;
            AddressLine2 = line2;
            City = city;
            StateProvince = state;
            CountryRegion= country;
        }
    }
}
