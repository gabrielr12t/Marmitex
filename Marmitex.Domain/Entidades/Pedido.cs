using System;
using System.Collections.Generic;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Enums;

namespace Marmitex.Domain.Entidades
{
    public class Pedido : Entity
    {
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public virtual Cliente Cliente { get; set; }
        public long ClienteId { get; set; }

        public OpcoesDeEntrega OpcaoEntrega { get; set; }
        public OpcoesDePagamento OpcaoPagamento { get; set; }

        public virtual ICollection<Marmita> Marmitas { get; set; }
        public virtual ICollection<ItensPedido> ItensPedidos { get; set; }


        public Pedido() { }

        public Pedido(decimal total, Cliente cliente, ICollection<Marmita> marmitas, OpcoesDeEntrega opcEntrega, OpcoesDePagamento opcPagamento)
        {
            ValidadeProperties(total, cliente, marmitas, opcEntrega, opcPagamento);
            SetProperties(total, cliente, marmitas, opcEntrega, opcPagamento);
        }

        private void ValidadeProperties(decimal total, Cliente cliente, ICollection<Marmita> marmitas, OpcoesDeEntrega opcEntrega, OpcoesDePagamento opcPagamento)
        {
            ExceptionClass.Exec(total < 0, "Total da compra inválido");
            ExceptionClass.Exec(cliente == null, "É necessário um cliente para efetuar a compra");
            ExceptionClass.Exec(marmitas == null, "Para efetuar a compra precisa de pelo menos uma marmita adicionada");
        }

        private void SetProperties(decimal total, Cliente cliente, ICollection<Marmita> marmitas, OpcoesDeEntrega opcEntrega, OpcoesDePagamento opcPagamento)
        {
            Marmitas = new List<Marmita>();
            this.Data = DateTime.Now;
            this.Total = total;
            this.ClienteId = cliente.Id;
            this.OpcaoEntrega = opcEntrega;
            this.OpcaoPagamento = opcPagamento;
        }
    }
}