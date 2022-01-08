using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MedsWebApp.Data;
using MedsWebApp.Models;

namespace MedsWebApp.Pages.Appointments
{
    public class DetailsModel : PageModel
    {
        private readonly MedsWebApp.Data.MedsWebAppContext _context;

        public DetailsModel(MedsWebApp.Data.MedsWebAppContext context)
        {
            _context = context;
        }

        public Appointment Appointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointment = await _context.Appointment.FirstOrDefaultAsync(m => m.ID == id);

            if (Appointment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
