using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HaircutManagementSystem.Data; // Include your DbContext namespace
using HaircutManagementSystem.Models; // Include your models namespace
using System.Collections.Generic;
using System.Linq;

namespace HaircutManagementSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HaircutDbContext _context;

        public IndexModel(HaircutDbContext context)
        {
            _context = context;
        }

        // Property to hold the list of services
        public List<Service> Services { get; set; }

        public void OnGet()
        {
            // Load Services data from the database
            Services = _context.Services.ToList();
        }
    }
}
