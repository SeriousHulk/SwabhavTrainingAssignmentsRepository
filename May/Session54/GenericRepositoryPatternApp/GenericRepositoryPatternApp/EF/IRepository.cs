namespace GenericRepositoryPatternApp.EF
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        void Add(T entry);
    }
}
