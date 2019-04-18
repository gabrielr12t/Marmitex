using System;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.Enums;

namespace Marmitex.Domain.Entidades
{
    public class Mistura : Cardapio
    {
        public decimal AcrescimoValor { get; set; } // exemplo feijoada

        public Mistura(string nome, decimal acrescimoValor, DateTime data)
        {
            SetProperties(nome, acrescimoValor, data);
        }
        public Mistura()
        {

        }

        private void SetProperties(string nome, decimal acrescimoValor, DateTime data)
        {
            this.Nome = nome;
            this.AcrescimoValor = acrescimoValor;
            this.Data = this.Id > 0 ? data : DateTime.Now;
            this.StatusCardapio = StatusCardapio.ATIVO;
        }

        public void Update(string nome, decimal acrescimoValor, DateTime data)
        {
            SetProperties(nome, acrescimoValor, data);
        }
    }
}