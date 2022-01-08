using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedsWebApp.Models
{
    public class AppointmentData
    {
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<AppointmentDepartment> AppointmentDepartments { get; set; }

    }
}
