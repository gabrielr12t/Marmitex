using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Marmitex.Domain.Entidades
{
    public class Marmita : Entity
    {
        public virtual Salada Salada { get; set; }
        public decimal Valor { get; private set; }
        public Tamanho Tamanho { get; set; }
        public virtual Mistura Mistura { get; set; }
        
        public string Observacao { get; set; }
        // teste
        public virtual IEnumerable<Salada> Saladas { get; set; }
        public virtual IEnumerable<Mistura> Misturas { get; set; }
        public virtual IEnumerable<Acompanhamento> Acompanhamentos { get; set; }
        // public virtual IEnumerable<Tamanho> Tamanhos { get; set; }


        public Marmita() { }
        public Marmita(Salada salada, Mistura mistura, decimal valor, Tamanho tamanho, List<Acompanhamento> acompanhamentos)
        {
            // mini = 12 reais 
            // normal = 14 reais
            Acompanhamentos = new List<Acompanhamento>(2);
            Acompanhamentos.ToList().AddRange(acompanhamentos);

            Valor = tamanho == Tamanho.Mini ? 12 : 14;
            if (Mistura.AcrescimoValor > 0)
            {
                Valor += Mistura.AcrescimoValor;
            }
        }
    }
}