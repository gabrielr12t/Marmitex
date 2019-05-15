using Marmitex.Domain.BaseEntity;

namespace Marmitex.Domain.Entidades
{
    public class ItensPedido : Entity
    {
        public virtual Pedido Pedido { get; set; }
        public long PedidoId { get; set; }
        public virtual Marmita Marmita { get; set; }
        public long MarmitaId { get; set; }

        public ItensPedido()
        {

        }
        public ItensPedido(Pedido pedido, Marmita marmita)
        {
            this.PedidoId = pedido.Id;
            this.MarmitaId = marmita.Id;
        }
    }
}