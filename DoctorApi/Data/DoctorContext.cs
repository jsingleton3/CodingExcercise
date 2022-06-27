using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DoctorApi.Models;

namespace DoctorApi.Data
{

    public class DoctorContext : DbContext
    {
        public DoctorContext(DbContextOptions<DoctorContext> options)
            : base(options)
        {
        }

        public DbSet<DoctorApi.Models.Doctor>? Doctor { get; set; }
    }
}