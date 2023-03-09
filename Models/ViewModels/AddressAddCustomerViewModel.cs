using Microsoft.AspNetCore.Mvc.Rendering;

namespace SD_330_Demos.Models.ViewModels
{
    public class AddressAddCustomerViewModel
    {
        public HashSet<SelectListItem> Customers { get; set; } = new HashSet<SelectListItem>();
        public HashSet<SelectListItem> Addresses { get; set; } = new HashSet<SelectListItem>();

        public int? CustomerId { get; set; }
        public int? AddressId { get; set; }

        public string? ViewMessage { get; set; }


        public void PopulateLists(IEnumerable<Customer> customers, IEnumerable<Address> addresses)
        {
            foreach (Customer c in customers)
            {
                Customers.Add(new SelectListItem($"{c.FirstName} {c.LastName}", c.Id.ToString()));
            }

            foreach (Address a in addresses)
            {
                Addresses.Add(new SelectListItem($"{a.AddressLine1} ({a.City}, {a.StateProvince})", a.Id.ToString()));
            }
        }

        // Interface parameters can take ANY child of parameter type as argument
        public AddressAddCustomerViewModel(IEnumerable<Customer> customers, IEnumerable<Address> addresses)
        {
            PopulateLists(customers, addresses);
        }

        public AddressAddCustomerViewModel()
        {

        }
    }
}
