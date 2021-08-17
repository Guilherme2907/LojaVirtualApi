using Guilherme.LojaVirtualApi.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Guilherme.LojaVirtualApi.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> FindById(long id);
        Task<IEnumerable<T>> FindAll();
        Task<T> Add(T t);
        Task<T> Update(T t);
        Task Delete(long id);
    }
}
