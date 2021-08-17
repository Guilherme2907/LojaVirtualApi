using Guilherme.LojaVirtualApi.Models.Entities.Enums;
using System;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpireTime { get; set; }
        public Role Role { get; set; }
    }
}
