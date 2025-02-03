using HaircutManagementSystem.Data;
using HaircutManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HaircutManagementSystem.Pages
{
    public class BarbersModel : PageModel
    {
        private readonly HaircutDbContext _context;

        public BarbersModel(HaircutDbContext context)
        {
            _context = context;
        }

        public IList<Barber> Barbers { get; set; }

        public async Task OnGetAsync()
        {
            Barbers = await _context.Barbers.ToListAsync();
        }

        public IActionResult OnPostCreate(Barber barber)
        {
            if (ModelState.IsValid)
            {
                _context.Barbers.Add(barber);
                _context.SaveChanges();
                return RedirectToPage();
            }
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            var barber = _context.Barbers.Find(id);
            if (barber != null)
            {
                _context.Barbers.Remove(barber);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
