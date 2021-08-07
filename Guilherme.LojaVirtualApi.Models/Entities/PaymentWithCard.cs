namespace Guilherme.LojaVirtualApi.Models.Entities
{
    public class PaymentWithCard : Payment
    {
        public int Installments { get; set; }
    }
}
