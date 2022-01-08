using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MedsWebApp.Data;

namespace MedsWebApp.Models
{
    public class AppointmentDepartmentsPageModel:PageModel
    {
        public List<AssignedDepartmentData> AssignedDepartmentDataList = new List<AssignedDepartmentData>();
        public void PopulateAssignedDepartmentData(MedsWebAppContext context, Appointment appointment)
        {
            var allDepartments = context.Department;
            var appointmentDepartments = new HashSet<int>(appointment.AppointmentDepartments.Select(d => d.DepartmentID));
            //AssignedDepartmentDataList = new List <AssignedDepartmentData>();
            foreach(var dep in allDepartments)
            {
                AssignedDepartmentDataList.Add(new AssignedDepartmentData
                {
                    DepartmentID = dep.ID,
                    Name = dep.DepartmentName,
                    Assigned = appointmentDepartments.Contains(dep.ID)
                });
            }
        }
        public void UpdateAppointmentDepartments(MedsWebAppContext context, string [] selectedDepartments, Appointment appointmentToUpdate)
        {
            if(selectedDepartments == null)
            {
                appointmentToUpdate.AppointmentDepartments = new List<AppointmentDepartment>();
                return;
            }
            var selectedDepartmentsHS = new HashSet<string>(selectedDepartments);
            var appointmentDepartments = new HashSet<int>(appointmentToUpdate.AppointmentDepartments.Select(d => d.DepartmentID));
            foreach (var dep in context.Department)
            {
                if (selectedDepartmentsHS.Contains(dep.ID.ToString()))
                {
                    if (!appointmentDepartments.Contains(dep.ID))
                    {
                        appointmentToUpdate.AppointmentDepartments.Add(new AppointmentDepartment
                        {
                            AppointmentID = appointmentToUpdate.ID,
                            DepartmentID = dep.ID
                        });
                    }
                }
                else
                {
                    if (appointmentDepartments.Contains(dep.ID))
                    {
                        AppointmentDepartment courseToRemove = appointmentToUpdate.AppointmentDepartments.SingleOrDefault(i => i.DepartmentID == dep.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }

        }
    }
}
