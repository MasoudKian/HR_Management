using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_Management.Application.Contract.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);

        //فقط اطلاعات رو میخونه واکشی میکنه
        Task<IReadOnlyList<T>> GetAll();
        Task<bool> Exist(int id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
