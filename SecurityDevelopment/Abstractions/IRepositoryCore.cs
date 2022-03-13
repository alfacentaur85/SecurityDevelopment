using System.Collections.Generic;
using System.Threading.Tasks;


namespace SecurityDevelopment.Abstractions
{
    public interface IRepositoryCore<T, R> where T : class where R : class
    {
        Task<IReadOnlyList<T>> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetByNameAsync(string name);
        Task<IReadOnlyList<T>> GetWithPaginationAsync(int skip, int take, string search);
        Task AddAsync(IReadOnlyList<R> item);
        Task UpdateAsync(IReadOnlyList<R> item);
        Task DeleteAsync(int id);

    }
}
