using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedsWebApp.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Affection { get; set; }
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }

        [Display(Name = "Department")]
        public ICollection<AppointmentDepartment> AppointmentDepartments { get; set; }
        public DateTime Date { get; set; }

    }
}
