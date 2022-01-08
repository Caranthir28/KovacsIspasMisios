using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedsWebApp.Models;

namespace MedsWebApp.Data
{
    public class MedsWebAppContext : DbContext
    {
        public MedsWebAppContext (DbContextOptions<MedsWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<MedsWebApp.Models.Appointment> Appointment { get; set; }

        public DbSet<MedsWebApp.Models.Doctor> Doctor { get; set; }

        public DbSet<MedsWebApp.Models.Department> Department { get; set; }
    }
}
