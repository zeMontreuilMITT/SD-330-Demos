using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SD_330_Demos.Models;
using SD_330_Demos.Data;
using SD_330_Demos.Models.ViewModels;


// CLIENT SIDE
// Client: user
// The "consumer" side of the application
// EX: Views

// SERVER SIDE
// "Delivering" side of the application

namespace SD_330_Demos.Controllers
{
    public class AddressesController : Controller
    {
        private readonly DemosContext _context;
        public AddressesController(DemosContext context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
              return View(await _context.Address
                  .Include(a => a.CustomerAddresses)
                  .ThenInclude(ca => ca.Customer)
                  .ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> AddCustomer()
        {
            // need dropdown of all Addresses and all Customers

            AddressAddCustomerViewModel vm = new AddressAddCustomerViewModel(_context.Customer.ToList(), _context.Address.ToList());

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddressAddCustomerViewModel vm)
        {
            if(vm.CustomerId != null && vm.AddressId != null)
            {
                // get customer and address, then add new CA
                //1: query customer and address
                // ensure customer not already registered for address
                if (!_context.CustomerAddress.Any(ca => ca.AddressId == vm.AddressId && ca.CustomerId == vm.CustomerId
                ))
                {
                    CustomerAddress customerAddress = new CustomerAddress();

                    Customer customer = _context.Customer.First(c => c.Id == vm.CustomerId);
                    Address address = _context.Address.First(a => a.Id == vm.AddressId);

                    customerAddress.Address = address;
                    customerAddress.Customer = customer;

                    _context.CustomerAddress.Add(customerAddress);
                    _context.SaveChanges();

                    vm.ViewMessage = $"Succesfully added {customer.FirstName} {customer.LastName} to {address.AddressLine1}";

                } else
                {
                    vm.ViewMessage = "Selected Customer already registered to Selected Address.";
                }

                vm.PopulateLists(_context.Customer.ToList(), _context.Address.ToList());

                return View(vm);
            }
            else
            {
                throw new Exception("Error retreiving Customer/Address Id");
            }
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Address == null)
            {
                return NotFound();
            }

            var address = await _context.Address
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AddressLine1,AddressLine2,City,StateProvince,CountryRegion")] Address address)
        {
            if (ModelState.IsValid)
            {   
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Address == null)
            {
                return NotFound();
            }

            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AddressLine1,AddressLine2,City,StateProvince,CountryRegion")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Address == null)
            {
                return NotFound();
            }

            var address = await _context.Address
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Address == null)
            {
                return Problem("Entity set 'DemosContext.Address'  is null.");
            }
            var address = await _context.Address.FindAsync(id);
            if (address != null)
            {
                _context.Address.Remove(address);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
          return _context.Address.Any(e => e.Id == id);
        }
    }
}
