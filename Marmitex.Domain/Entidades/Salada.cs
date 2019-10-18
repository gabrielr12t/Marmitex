using System;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Enums;
using Marmitex.Domain.Interfaces.ModelsInterfaces;

namespace Marmitex.Domain.Entidades
{
    public class Salada : IModelBase<Salada>, ICardapioBase
    {
        public Salada() { }
        public Salada(Salada salada)
        {
            Validation(salada);
            SetProperties(salada);
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public StatusCardapio StatusCardapio { get; set; }

        public void Update(Salada salada)
        {
            Validation(salada);
            SetProperties(salada);
        }

        public void Validation(Salada salada)
        {
            ExceptionClass.Exec(string.IsNullOrEmpty(salada.Nome), "Campo nome é obrigatório");
        }

        public void SetProperties(Salada salada)
        {
            this.Nome = salada.Nome.Trim();
            this.Data = this.Id != Guid.Empty ? salada.Data : DateTime.Now;
            this.StatusCardapio = StatusCardapio.ATIVO;
        }
    }
}