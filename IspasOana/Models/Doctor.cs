using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedsWebApp.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string DoctorName { get; set; }
        public ICollection<Appointment> Appointments { get; set; } //navigation property

    }
}
