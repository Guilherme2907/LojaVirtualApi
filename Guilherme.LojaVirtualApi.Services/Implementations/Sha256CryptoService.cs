using Guilherme.LojaVirtualApi.Services.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Guilherme.LojaVirtualApi.Services.Implementations
{
    public class Sha256CryptoService : ICryptographyService
    {
        public string EncryptPassword(string password)
        {
            var algorithm = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(password);

            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
