using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedsWebApp.Models
{
    public class AppointmentDepartment
    {
        public int ID { get; set; }
        public int AppointmentID { get; set; }
        public Appointment Appointment { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
