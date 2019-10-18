using System;
using System.Collections.Generic;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Enums;
using Marmitex.Domain.Interfaces.ModelsInterfaces;

namespace Marmitex.Domain.Entidades
{
    public class Acompanhamento : ICardapioBase, IModelBase<Acompanhamento>
    {
        public Acompanhamento() { }
        public Acompanhamento(Acompanhamento acompanhamento)
        {
            SetProperties(acompanhamento);
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public StatusCardapio StatusCardapio { get; set; }

        public void Validation(Acompanhamento t)
        {
            ExceptionClass.Exec(string.IsNullOrEmpty(Nome), "Nome não pode ser vazio");
            ExceptionClass.Exec(Nome.Length < 3, "Nome não pode ter menos que 3 caracteres");
            ExceptionClass.Exec(Nome.Length > 30, "Nome não pode ter mais que 30 caracteres");
        }
        public void SetProperties(Acompanhamento acompanhamento)
        {
            ExceptionClass.Exec(string.IsNullOrEmpty(acompanhamento.Nome), "Campo nome é obrigatório");
            this.Nome = acompanhamento.Nome.Trim();
            this.Data = this.Id != Guid.Empty ? acompanhamento.Data : DateTime.Now;
            this.StatusCardapio = StatusCardapio.ATIVO;
        }

        public void Update(Acompanhamento acompanhamento)
        {
            SetProperties(acompanhamento);
        }
    }
}