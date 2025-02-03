using HaircutManagementSystem.Data;
using HaircutManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HaircutManagementSystem.Pages
{
    public class ServicesModel : PageModel
    {
        private readonly HaircutDbContext _context;

        public ServicesModel(HaircutDbContext context)
        {
            _context = context;
        }

        public IList<Service> Services { get; set; }

        public async Task OnGetAsync()
        {
            Services = await _context.Services.ToListAsync();
        }

        public IActionResult OnPostCreate(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                _context.SaveChanges();
                return RedirectToPage();
            }
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            var service = _context.Services.Find(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
