using GenericRepositoryPatternApp.Data;

namespace GenericRepositoryPatternApp.EF
{
    public class MonoceptEFGenericRepository<T> : IRepository<T>
        where T : class
    {
        private readonly OrganizationDbContext _db;
        public MonoceptEFGenericRepository(OrganizationDbContext organizationDb)
        {
            _db = organizationDb;            
        }
        public void Add(T entry)
        {
            _db.Set<T>().Add(entry);
            _db.SaveChanges(); 
        }

        public IQueryable<T> Get()
        {
            return _db.Set<T>();
        }
    }
}
