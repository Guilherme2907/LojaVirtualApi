using System.Threading.Tasks;

namespace Guilherme.LojaVirtualApi.Services.Interfaces
{
    public interface ICryptographyService
    {
        string EncryptPassword(string password);
    }
}
