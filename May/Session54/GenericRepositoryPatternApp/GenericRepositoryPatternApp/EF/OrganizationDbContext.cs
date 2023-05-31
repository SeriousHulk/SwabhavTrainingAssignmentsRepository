using GenericRepositoryPatternApp.Model;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryPatternApp.Data
{
    public class OrganizationDbContext:DbContext
    {
        public OrganizationDbContext(DbContextOptions<OrganizationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Organization> Organizations { get; set; }
    }
}
