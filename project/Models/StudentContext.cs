using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class StudentContext: DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options):base(options)
        {

        }
        public DbSet<Student> tbl_student1 { get; set; }
        //public DbSet<Student> tbl_student { get; set; }

    }
}
