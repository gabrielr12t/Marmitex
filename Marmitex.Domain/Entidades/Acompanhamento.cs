using System;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Enums;

namespace Marmitex.Domain.Entidades
{
    public class Acompanhamento : Cardapio
    {
        public Acompanhamento()
        {

        }
        public Acompanhamento(string nome, DateTime data)
        {
            SetPropertiesAndValidateNome(nome, data);
        }


        private void SetPropertiesAndValidateNome(string nome, DateTime data)
        {
            DomainException.When(string.IsNullOrEmpty(nome), "Campo nome é obrigatório");
            this.Nome = nome;
            this.Data = this.Id > 0 ? data : DateTime.Now;
            this.StatusCardapio = StatusCardapio.ATIVO;
        }

        public void Update(string nome, decimal acrescimoValor, DateTime data)
        {
            SetPropertiesAndValidateNome(nome, data);
        }
    }
}