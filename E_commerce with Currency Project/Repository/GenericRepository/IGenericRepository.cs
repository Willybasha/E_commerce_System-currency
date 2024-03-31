using System.Linq.Expressions;

namespace E_commerce_System_currency.Repository.GenericRepository
{
    public interface IGenericRepository<T> 
    {
        /*  Task<IEnumerable<T>> GetAllAsync();

          Task<T?> FindByIdAsync(int Id);

          Task<bool> AddAsync(T Entity);

          bool Update(T Entity);

          Task<bool> DeleteAsync(int Id);*/
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
