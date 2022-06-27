using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleApp.Models;

public class DoctorContext : DbContext
{
    public DoctorContext (DbContextOptions<DoctorContext> options)
            : base(options)
    {
    }

    public DbSet<SampleApp.Models.Doctor>? Doctor { get; set; }

}
