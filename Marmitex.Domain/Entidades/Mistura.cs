using System;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Enums;

namespace Marmitex.Domain.Entidades
{
    public class Mistura : Cardapio
    {
        public decimal AcrescimoValor { get; set; } // exemplo feijoada

        public Mistura(string nome, decimal acrescimoValor, DateTime data)
        {
            SetPropertiesAndValidateNome(nome, acrescimoValor, data);
        }
        public Mistura()
        {

        }

        private void SetPropertiesAndValidateNome(string nome, decimal acrescimoValor, DateTime data)
        {
            DomainException.When(string.IsNullOrEmpty(nome), "Campo nome é obrigatório");
            this.Nome = nome;
            this.AcrescimoValor = acrescimoValor;
            this.Data = this.Id > 0 ? data : DateTime.Now;
            this.StatusCardapio = StatusCardapio.ATIVO;
        }

        public void Update(string nome, decimal acrescimoValor, DateTime data)
        {
            SetPropertiesAndValidateNome(nome, acrescimoValor, data);
        }
    }
}