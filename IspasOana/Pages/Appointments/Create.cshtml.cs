using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedsWebApp.Data;
using MedsWebApp.Models;

namespace MedsWebApp.Pages.Appointments
{
    public class CreateModel : AppointmentDepartmentsPageModel
    {
        private readonly MedsWebApp.Data.MedsWebAppContext _context;

        public CreateModel(MedsWebApp.Data.MedsWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DoctorID"] = new SelectList(_context.Set<Doctor>(), "ID", "DoctorName");

            var appointment = new Appointment();
            appointment.AppointmentDepartments = new List<AppointmentDepartment>();

            PopulateAssignedDepartmentData(_context, appointment);

            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; }


        /* public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        } */

        public async Task<IActionResult> OnPostAsync(string[] selectedDepartments, int DId)
        {
            var newAppointment = new Appointment();
            if (selectedDepartments != null)
            {
                newAppointment.AppointmentDepartments = new List<AppointmentDepartment>();
                foreach (var dep in selectedDepartments)
                {
                    var depToAdd = new AppointmentDepartment
                    {
                        DepartmentID = int.Parse(dep)
                    };
                    newAppointment.AppointmentDepartments.Add(depToAdd);

                    newAppointment.DoctorID = DId;
                }
            }
            if (await TryUpdateModelAsync<Appointment>(
                 newAppointment,
                 "Appointment",
                 i => i.FirstName, i => i.LastName,
                 i => i.Affection, i => i.Doctor, i => i.Date))
            {
                _context.Appointment.Add(newAppointment);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedDepartmentData(_context, newAppointment);
            return Page();
        }
    }
}


