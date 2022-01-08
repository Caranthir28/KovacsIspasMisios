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
    public class IndexModel : PageModel
    {
        private readonly MedsWebApp.Data.MedsWebAppContext _context;

        public IndexModel(MedsWebApp.Data.MedsWebAppContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get; set; }
        public AppointmentData AppointmentD { get; set; }
        public int AppointmentID { get; set; }
        public int DepartmentID { get; set; }

        public async Task OnGetAsync(int? id, int? departmentID)
        {
            AppointmentD = new AppointmentData();

            AppointmentD.Appointments = await _context.Appointment
            .Include(a => a.Doctor)
            .Include(a => a.AppointmentDepartments)
            .ThenInclude(a => a.Department)
            .AsNoTracking()
            .OrderBy(a => a.FirstName)
            .ToListAsync();

            if (id != null)
            {
                AppointmentID = id.Value;
                Appointment appointment = AppointmentD.Appointments.Where(i => i.ID == id.Value).Single();
                AppointmentD.Departments = appointment.AppointmentDepartments.Select(s => s.Department);
            }
        }
    
    }
} 

