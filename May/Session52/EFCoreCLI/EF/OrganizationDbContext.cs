using EFcoreCLI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcoreCLI.EF
{
    internal class OrganizationDbContext : DbContext
    {
        public DbSet<Organization> organizations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=OrganizationDb;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
