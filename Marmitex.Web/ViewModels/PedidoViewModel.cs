using System;
using System.Collections.Generic;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Enums;

namespace Marmitex.Web.ViewModels
{
    public class PedidoViewModel
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }
        public long ClienteId { get; set; }
        public OpcoesDeEntrega OpcaoEntrega { get; set; }
        public OpcoesDePagamento OpcaoPagamento { get; set; }
        public virtual ICollection<MarmitaViewModel> Marmitas { get; set; }
        public Status Status { get; set; }
    }
}