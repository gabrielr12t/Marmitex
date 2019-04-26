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
            SetPropertiesAndValidateNomeAndValor(nome, acrescimoValor, data);
        }
        public Mistura()
        {

        }

        private void SetPropertiesAndValidateNomeAndValor(string nome, decimal acrescimoValor, DateTime data)
        {
            ExceptionClass.Exec(string.IsNullOrEmpty(nome), "Campo nome é obrigatório");
            ExceptionClass.Exec(acrescimoValor < 0, "Valor não pode ser menor que zero");
            this.Nome = nome.Trim();
            this.AcrescimoValor = acrescimoValor;
            this.Data = this.Id > 0 ? data : DateTime.Now;
            this.StatusCardapio = StatusCardapio.ATIVO;
        }

        public void Update(string nome, decimal acrescimoValor, DateTime data)
        {
            SetPropertiesAndValidateNomeAndValor(nome, acrescimoValor, data);
        }
    }
}