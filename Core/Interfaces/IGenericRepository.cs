using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T? GetById(int id);
        Task<T> GetByIdAsync(int id);
        T? Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        ICollection<T> ListAll();
        Task<IReadOnlyList<T>> ListAllAsync();
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        T Add(T t);
        Task<T> AddAsync(T t);
        T Update(T updated,int key);
        Task<T> UpdateAsync(T updated, int key);
        bool Delete(T t);
        Task<int> DeleteAsync(T t);
        int Count();
        Task<int> CountAsync();
    }
}
