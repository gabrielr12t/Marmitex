using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marmitex.Domain.Entidades
{
    public class Marmita : Entity
    {

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


        public Marmita() { this.Acompanhamentos = new HashSet<Acompanhamento>(); }


        //
        public Marmita(Mistura mistura, decimal valor, Salada salada, Tamanho tamanho, decimal acrescimo, string obs,
            ICollection<Acompanhamento> acompanhamentos, Cliente cliente, Pedido pedido)
        {
            Acompanhamentos = new List<Acompanhamento>();
            ValidateProperties(salada, mistura, valor, tamanho, acrescimo, acompanhamentos, cliente);
            SetProperties(salada, mistura, valor, obs, tamanho, acrescimo, acompanhamentos, pedido);
        }

        private void ValidateProperties(Salada salada, Mistura mistura, decimal valor, Tamanho tamanho, decimal acrescimo,
         ICollection<Acompanhamento> acompanhamentos, Cliente cliente)
        {
            ExceptionClass.Exec(mistura == null, "Mistura é obrigatória");
            ExceptionClass.Exec(salada == null, "Salada é obrigatória");
            ExceptionClass.Exec(valor < 0, "Valor inválido");
            ExceptionClass.Exec(acrescimo < 0, "Valor inválido");
            ExceptionClass.Exec(acompanhamentos.Count() > 2, "Proibido mais de dois acompanhamentos em uma marmita");
            ExceptionClass.Exec(tamanho.ToString().Equals(string.Empty), "Tamanho inválido");
            ExceptionClass.Exec(cliente == null, "Cliente inválido");
        }
        private void SetProperties(Salada salada, Mistura mistura, decimal valor, string obs, Tamanho tamanho, decimal acrescimo,
        ICollection<Acompanhamento> acompanhamentos, Pedido pedido)
        {
            this.Valor = tamanho == Tamanho.Mini ? 12 : 14;
            if (acrescimo > 0) this.Valor += acrescimo;
            this.SaladaId = salada.Id;
            this.Observacao = obs;
            this.MisturaId = mistura.Id;
            this.Tamanho = tamanho;
            this.PedidoId = pedido.Id;
        }
    }
}