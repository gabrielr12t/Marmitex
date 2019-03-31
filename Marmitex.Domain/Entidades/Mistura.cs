using System;
using Marmitex.Domain.BaseEntity;

namespace Marmitex.Domain.Entidades
{
    public class Mistura : Entity
    {
        public string Nome { get; set; }
        public DateTime Data { get; private set; }
        public decimal AcrescimoValor { get; set; } // exemplo feijoada
        public Mistura(string nome, decimal acrescimoValor)
        {
            this.Nome = nome;
            this.AcrescimoValor = acrescimoValor;
            this.Data = DateTime.Now;
        }
         
    }
}