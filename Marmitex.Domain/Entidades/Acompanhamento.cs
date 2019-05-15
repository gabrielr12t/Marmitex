using System;
using System.Collections.Generic;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Enums;

namespace Marmitex.Domain.Entidades
{
    public class Acompanhamento : Cardapio
    {
        public virtual ICollection<Marmita> Marmitas { get; set; }
        public Acompanhamento()
        {
            this.Marmitas = new HashSet<Marmita>();
        }
        public Acompanhamento(string nome, DateTime data)
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

        public void Update(string nome, DateTime data)
        {
            SetPropertiesAndValidateNome(nome, data);
        }
    }
}