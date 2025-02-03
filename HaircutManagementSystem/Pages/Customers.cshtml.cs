using HaircutManagementSystem.Data;
using HaircutManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HaircutManagementSystem.Pages
{
    public class CustomersModel : PageModel
    {
        private readonly HaircutDbContext _context;

        public CustomersModel(HaircutDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        // Display all customers
        public async Task OnGetAsync()
        {
            Customers = await _context.Customers.ToListAsync();
        }

        // Add a new customer
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(Customer);
                await _context.SaveChangesAsync();
                return RedirectToPage(); // Refresh the page
            }
            return Page();
        }

        // Load customer for editing
        public async Task<IActionResult> OnGetEditAsync(int id)
        {
            Customer = await _context.Customers.FindAsync(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        // Save changes after editing
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage();
        }

        // Delete customer
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.ID == id);
        }
    }
}
