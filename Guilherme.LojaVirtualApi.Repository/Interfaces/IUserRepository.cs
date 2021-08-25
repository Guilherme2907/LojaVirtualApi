using Guilherme.LojaVirtualApi.Models.DTOs.Requests;
using Guilherme.LojaVirtualApi.Models.Entities;
using System.Threading.Tasks;

namespace Guilherme.LojaVirtualApi.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByCredentialsAsync(string username,string password);
        Task<User> FindByUsernameAsync(string username);
    }
}
