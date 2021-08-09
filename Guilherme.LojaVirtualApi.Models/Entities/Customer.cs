using Guilherme.LojaVirtualApi.Models.Entities.Enums;
using System.Collections.Generic;

namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public CustomerType CustomerType { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Telephone> Telephones { get; set; }
    }
}
