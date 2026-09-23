namespace JobApplication.Application.Interfaces
{
    // Generic repository. Implemented in Infrastructure (Repository<T>), so Application stays free of EF Core.
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get();
        Task AddAsync(T entity);
        Task SaveChangesAsync();
    }
}
