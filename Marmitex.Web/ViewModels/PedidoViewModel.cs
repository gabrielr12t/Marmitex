using System;
using System.Collections.Generic;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Enums;

namespace Marmitex.Web.ViewModels
{
    public class PedidoViewModel
    {
        public List<Pedido> Pedidos { get; set; }
        public List<ItensPedido> ItensPedidos { get; set; }
        // public long Id { get; set; }
        // public DateTime Data { get; private set; }
        // public decimal Total { get; set; }
        // public virtual ClienteViewModel Cliente { get; set; }
        // public long ClienteId { get; set; }

        // public OpcoesDeEntrega OpcaoEntrega { get; set; }
        // public OpcoesDePagamento OpcaoPagamento { get; set; }
    }
}