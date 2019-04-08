using System;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.Enums;

namespace Marmitex.Domain.Entidades
{
    public class Pedido : Entity
    {
        public DateTime Data { get; private set; }
        public decimal Total { get; set; }
        public virtual Cliente Cliente { get; set; }

        public OpcoesDeEntrega OpcaoEntrega { get; set; }
        public OpcoesDePagamento OpcaoPagamento { get; set; }


        public Pedido()
        {
            Data = DateTime.Now;
        }
    }
}