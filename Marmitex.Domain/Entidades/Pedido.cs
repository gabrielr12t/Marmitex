using System;
using System.Collections.Generic;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Enums;
using Marmitex.Domain.Interfaces.ModelsInterfaces;

namespace Marmitex.Domain.Entidades
{
    public class Pedido : IModelBase<Pedido>
    {
        public Pedido() { }

        public Pedido(Pedido pedido)
        {
            Validation(pedido);
            SetProperties(pedido);
        }

        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public virtual Cliente Cliente { get; set; }
        public OpcoesDeEntrega OpcaoEntrega { get; set; }
        public OpcoesDePagamento OpcaoPagamento { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<Marmita> Marmitas { get; set; }

        public void Validation(Pedido pedido)
        {
            ExceptionClass.Exec(pedido.Total < 0, "Total da compra inválido");
            ExceptionClass.Exec(pedido.Cliente == null, "É necessário um cliente para efetuar a compra");
            ExceptionClass.Exec(pedido.Marmitas == null || pedido.Marmitas.Count == 0, "Para efetuar a compra precisa de pelo menos uma marmita adicionada");
        }

        public void SetProperties(Pedido pedido)
        {
            this.Marmitas = new List<Marmita>();
            this.Data = DateTime.Now;
            this.Total = pedido.Total;
            this.Id = pedido.Cliente.Id;
            this.OpcaoEntrega = pedido.OpcaoEntrega;
            this.OpcaoPagamento = pedido.OpcaoPagamento;
            this.Status = pedido.Status;
        }
    }
}