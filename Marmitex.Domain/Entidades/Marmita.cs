using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Enums;
using Marmitex.Domain.Interfaces.ModelsInterfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marmitex.Domain.Entidades
{
    public class Marmita : IModelBase<Marmita>
    {
        public Guid Id { get; set; }
        public virtual Salada Salada { get; set; }
        public long SaladaId { get; set; }
        public decimal Valor { get; set; }
        public virtual Tamanho Tamanho { get; set; }
        public virtual Mistura Mistura { get; set; }
        public long MisturaId { get; set; }
        public string Observacao { get; set; }
        public virtual Pedido Pedido { get; set; }
        public long PedidoId { get; set; }
        public virtual ICollection<Acompanhamento> Acompanhamentos { get; set; }// remover esse atributo
        public virtual ICollection<MarmitaAcompanhamento> MarmitaAcompanhamentos { get; set; }

        public Marmita()
        {
            this.Acompanhamentos = new HashSet<Acompanhamento>();
        }

        public Marmita(Marmita marmita)
        {
            Acompanhamentos = new List<Acompanhamento>();
            Validation(marmita);
            SetProperties(marmita);
        }
        public void Validation(Marmita marmita)
        {
            ExceptionClass.Exec(marmita.Mistura == null, "Mistura é obrigatória");
            ExceptionClass.Exec(marmita.Salada == null, "Salada é obrigatória");
            ExceptionClass.Exec(marmita.Valor < 0, "Valor inválido");
            ExceptionClass.Exec(marmita.Mistura.AcrescimoValor < 0, "Valor inválido");
            ExceptionClass.Exec(marmita.Acompanhamentos.Count() > 2, "Proibido mais de dois acompanhamentos em uma marmita");
            ExceptionClass.Exec(marmita.Tamanho.ToString().Equals(string.Empty), "Tamanho inválido");
            ExceptionClass.Exec(marmita.Pedido.Cliente == null, "Cliente inválido");
        }

        public void SetProperties(Marmita marmita)
        {
            this.Valor = marmita.Tamanho == Tamanho.Mini ? 12 : 14;
            if (marmita.Mistura.AcrescimoValor > 0) this.Valor += marmita.Mistura.AcrescimoValor;
            this.SaladaId = marmita.SaladaId;
            this.Observacao = marmita.Observacao;
            this.MisturaId = marmita.MisturaId;
            this.Tamanho = marmita.Tamanho;
            this.PedidoId = marmita.PedidoId;
        }
    }
}