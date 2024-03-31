
using System.Linq.Expressions;
using E_commerce_System_currency.Context;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_System_currency.Repository.GenericRepository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext Context) => _context = Context;


        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? _context.Set<T>().AsNoTracking()
           : _context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>!trackChanges ?_context.Set<T>().Where(expression).AsNoTracking()
            : _context.Set<T>().Where(expression);

        public void Create(T entity) => _context.Set<T>().Add(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
    }
}
