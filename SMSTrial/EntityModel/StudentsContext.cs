using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.IO;

namespace SMSTrial.EntityModel
{
    public partial class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<student_tbl> student_tbls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<student_tbl>().Property(e => e.id).IsRequired(true);
            modelBuilder.Entity<student_tbl>().Property(e => e.fname).IsRequired(false);
            modelBuilder.Entity<student_tbl>().Property(e => e.lname).IsRequired(false);
            modelBuilder.Entity<student_tbl>().Property(e => e.department).IsRequired(false);
        }
    }
}
