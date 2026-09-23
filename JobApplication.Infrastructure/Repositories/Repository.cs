using JobApplication.Application.Interfaces;
using JobApplication.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.Infrastructure.Repositories
{
    // One generic repository for every entity (Job, Candidate, JobCandidateApplication).
    // Registered in Program.cs as: AddScoped(typeof(IRepository<>), typeof(Repository<>))
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _set;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public IQueryable<T> Get()
        {
            return _set.AsQueryable();
        }

        public async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
