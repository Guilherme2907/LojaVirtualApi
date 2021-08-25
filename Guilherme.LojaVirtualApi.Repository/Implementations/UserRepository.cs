using Guilherme.LojaVirtualApi.Models.DTOs.Requests;
using Guilherme.LojaVirtualApi.Models.Entities;
using Guilherme.LojaVirtualApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Guilherme.LojaVirtualApi.Repository.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(EFContext context) : base(context)
        {
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(username));
        }

        public async Task<User> GetUserByCredentialsAsync(string username,string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(username) && u.Password.Equals(password));
        }
    }
}
