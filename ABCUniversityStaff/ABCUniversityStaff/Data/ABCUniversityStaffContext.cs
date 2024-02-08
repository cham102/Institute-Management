using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ABCUniversityStaff.models;

namespace ABCUniversityStaff.Data
{
    public class ABCUniversityStaffContext : DbContext
    {
        public ABCUniversityStaffContext (DbContextOptions<ABCUniversityStaffContext> options)
            : base(options)
        {
        }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<Student>().ToTable("Student");

        }
     
        //public DbSet<ABCUniversitySt.models.Student> Student { get; set; }
    }
}
