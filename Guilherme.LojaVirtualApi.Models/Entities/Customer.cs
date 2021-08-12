using Guilherme.LojaVirtualApi.Models.Entities.Enums;
using Newtonsoft.Json;
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
        public virtual ICollection<Address> Addresses { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Telephone> Telephones { get; set; }
    }
}
