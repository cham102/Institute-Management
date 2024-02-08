using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ABCUniversity1.models;

namespace ABCUniversity1.Data
{
    public class ABCUniversity1Context : DbContext
    {
        public ABCUniversity1Context (DbContextOptions<ABCUniversity1Context> options)
            : base(options)
        {
        }

        public DbSet<ABCUniversity1.models.student> student { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<student>().ToTable("Student");
        }
    }
}
