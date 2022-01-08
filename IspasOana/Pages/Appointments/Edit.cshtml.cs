using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedsWebApp.Data;
using MedsWebApp.Models;

namespace MedsWebApp.Pages.Appointments
{
    public class EditModel : AppointmentDepartmentsPageModel
    {
        private readonly MedsWebApp.Data.MedsWebAppContext _context;

        public EditModel(MedsWebApp.Data.MedsWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointment = await _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.AppointmentDepartments).ThenInclude(a => a.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Appointment == null)
            {
                return NotFound();
            }
            //calling PopulateAssignedDepartmentData for reciving the needed information

            PopulateAssignedDepartmentData(_context, Appointment);

            ViewData["DoctorID"] = new SelectList(_context.Set<Doctor>(), "ID", "DoctorName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedDepartments)
        {
            if (id == null)
            {
                return NotFound();
            }
            var appointmentToUpdate = await _context.Appointment
            .Include(i => i.Doctor)
            .Include(i => i.AppointmentDepartments)
            .ThenInclude(i => i.Department)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (appointmentToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Appointment>(
            appointmentToUpdate,
            "Appointment",
            i => i.FirstName, i => i.LastName,
            i => i.Affection, i => i.Doctor, i => i.Date))
            {
                UpdateAppointmentDepartments(_context, selectedDepartments, appointmentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateAppointmentDepartments(_context, selectedDepartments, appointmentToUpdate);
            PopulateAssignedDepartmentData(_context, appointmentToUpdate);
            return Page();
        }
    }
}
