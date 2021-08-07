namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public State State { get; set; }
    }
}
