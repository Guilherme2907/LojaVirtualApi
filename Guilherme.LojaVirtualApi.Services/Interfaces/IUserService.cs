using Guilherme.LojaVirtualApi.Models.DTOs;
using Guilherme.LojaVirtualApi.Models.DTOs.Requests;
using System.Threading.Tasks;

namespace Guilherme.LojaVirtualApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<TokenDto> SignIn(UserDto user);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}
