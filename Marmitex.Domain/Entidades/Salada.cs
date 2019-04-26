using System;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Enums;

namespace Marmitex.Domain.Entidades
{
    public class Salada : Cardapio
    {
        public Salada()
        {

        }
        public Salada(string nome, DateTime data)
        {
            SetPropertiesAndValidateNome(nome, data);
        }
        public void Update(string nome, DateTime data)
        {
            SetPropertiesAndValidateNome(nome, data);
        }
        private void SetPropertiesAndValidateNome(string nome, DateTime data)
        {
            ExceptionClass.Exec(string.IsNullOrEmpty(nome), "Campo nome é obrigatório");
            this.Nome = nome.Trim();
            this.Data = this.Id > 0 ? data : DateTime.Now;
            this.StatusCardapio = StatusCardapio.ATIVO;
        }
    }
}