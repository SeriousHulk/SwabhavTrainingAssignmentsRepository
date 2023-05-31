using CustomAnnotationPOC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomAnnotationPOC.EF
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext() : base("StudentDbContext")
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}