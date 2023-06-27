using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoWebApp.Data;
using DemoWebApp.Models;

namespace DemoWebApp.Views
{
    public class ShowSearchFormModel : PageModel
    {
        private readonly DemoWebApp.Data.ApplicationDbContext _context;

        public ShowSearchFormModel(DemoWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Joke Joke { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Joke == null || Joke == null)
            {
                return Page();
            }

            _context.Joke.Add(Joke);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
