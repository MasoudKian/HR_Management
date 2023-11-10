using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_Management.Application.Persistence.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);

        //فقط اطلاعات رو میخونه واکشی میکنه
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
