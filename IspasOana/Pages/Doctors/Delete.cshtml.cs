using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MedsWebApp.Data;
using MedsWebApp.Models;

namespace MedsWebApp.Pages.Doctors
{
    public class DeleteModel : PageModel
    {
        private readonly MedsWebApp.Data.MedsWebAppContext _context;

        public DeleteModel(MedsWebApp.Data.MedsWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doctor Doctor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor = await _context.Doctor.FirstOrDefaultAsync(m => m.ID == id);

            if (Doctor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor = await _context.Doctor.FindAsync(id);

            if (Doctor != null)
            {
                _context.Doctor.Remove(Doctor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
