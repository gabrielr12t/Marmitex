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
        public virtual ICollection<Acompanhamento> Acompanhamentos { get; set; }         


        public Marmita() { this.Acompanhamentos = new HashSet<Acompanhamento>(); }

        public Marmita(long misturaId, decimal valor, long saladaId, Tamanho tamanho, decimal acrescimo, string obs,
        ICollection<Acompanhamento> acompanhamentos, Cliente cliente, Pedido pedido)
        {
            Acompanhamentos = new List<Acompanhamento>();
            ValidateProperties(saladaId, misturaId, valor, tamanho, acrescimo, acompanhamentos, cliente);
            SetProperties(saladaId, misturaId, valor, obs, tamanho, acrescimo, acompanhamentos, pedido);
        }

        private void ValidateProperties(long saladaId, long misturaId, decimal valor, Tamanho tamanho, decimal acrescimo,
         ICollection<Acompanhamento> acompanhamentos, Cliente cliente)
        {
            ExceptionClass.Exec(misturaId < 0, "Mistura é obrigatória");
            ExceptionClass.Exec(saladaId < 0, "Salada é obrigatória");
            ExceptionClass.Exec(valor < 0, "Valor inválido");
            ExceptionClass.Exec(acrescimo < 0, "Valor inválido");
            ExceptionClass.Exec(acompanhamentos.Count() > 2, "Proibido mais de dois acompanhamentos em uma marmita");
            ExceptionClass.Exec(tamanho.ToString().Equals(string.Empty), "Tamanho inválido");
            ExceptionClass.Exec(cliente == null, "Cliente inválido");
        }
        private void SetProperties(long saladaId, long misturaId, decimal valor, string obs, Tamanho tamanho, decimal acrescimo,
        ICollection<Acompanhamento> acompanhamentos, Pedido pedido)
        {
            this.Valor = tamanho == Tamanho.Mini ? 12 : 14;
            if (acrescimo > 0) this.Valor += acrescimo;
            this.SaladaId = saladaId;
            this.Observacao = obs;
            this.MisturaId = misturaId;
            this.Tamanho = tamanho;
            //this.Pedido = pedido;
            //this.Acompanhamentos = acompanhamentos;
            //this.PedidoId = pedido.Id;
        }
    }
}