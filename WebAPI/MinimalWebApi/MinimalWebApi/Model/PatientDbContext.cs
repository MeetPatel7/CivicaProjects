using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDemo.Model
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext()
        {

        }

        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patient { get; set; }


    }
}
