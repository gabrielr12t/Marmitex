using Marmitex.Domain.BaseEntity;

namespace Marmitex.Domain.Entidades
{
    public class ItensPedido : Entity
    {
        public virtual Pedido Pedido { get; set; }
        public virtual Marmita Marmita { get; set; }        
    }
}