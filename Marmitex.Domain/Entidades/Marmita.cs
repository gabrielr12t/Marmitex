using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marmitex.Domain.Entidades
{
    public class Marmita : Entity
    {
        // public long SaladaId { get; set; }
        public virtual Salada Salada { get; set; }
        public decimal Valor { get; private set; }
        public Tamanho Tamanho { get; set; }
        // public long MisturaId { get; set; }
        public virtual Mistura Mistura { get; set; }

        public string Observacao { get; set; }
        // teste
        public virtual IEnumerable<Salada> Saladas { get; set; }
        public virtual IEnumerable<Mistura> Misturas { get; set; }
        public virtual IEnumerable<Acompanhamento> Acompanhamentos { get; set; }
        // public virtual IEnumerable<Tamanho> Tamanhos { get; set; }
        public Marmita() { Acompanhamentos = new List<Acompanhamento>(2); }
        public Marmita(Salada salada, Mistura mistura, decimal valor, Tamanho tamanho, List<Acompanhamento> acompanhamentos)
        {
            Mistura = new Mistura();
            Salada = new Salada();
            
            Acompanhamentos = new List<Acompanhamento>(2);
            SetProperties(salada, mistura, valor, tamanho, acompanhamentos);
        }

        private void SetProperties(Salada salada, Mistura mistura, decimal valor, Tamanho tamanho, List<Acompanhamento> acompanhamentos)
        {
            // mini = 12 reais 
            // normal = 14 reais
            this.Valor = tamanho == Tamanho.Mini ? 12 : 14;
            if (mistura.AcrescimoValor > 0)
            {
                this.Valor += mistura.AcrescimoValor;
            }
            this.Salada.Id = salada.Id;
            this.Mistura.Id = mistura.Id;
            this.Tamanho = tamanho;
            this.Acompanhamentos = acompanhamentos;
            // Acompanhamentos.ToList().AddRange(acompanhamentos);
        }
    }
}