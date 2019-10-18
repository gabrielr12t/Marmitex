using System;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Enums;
using Marmitex.Domain.Interfaces.ModelsInterfaces;

namespace Marmitex.Domain.Entidades
{
    public class Mistura : ICardapioBase, IModelBase<Mistura>
    {
        public Mistura(decimal acrescimoValor)
        {
            this.AcrescimoValor = acrescimoValor;
        }
        public Mistura(Mistura mistura)
        {
            Validation(mistura);
            SetProperties(mistura);
        }
        public Mistura()
        {

        }
        public Guid Id { get; set; }
        public decimal AcrescimoValor { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public StatusCardapio StatusCardapio { get; set; }

        public void Validation(Mistura mistura)
        {
            ExceptionClass.Exec(string.IsNullOrEmpty(mistura.Nome), "Campo nome é obrigatório");
            ExceptionClass.Exec(mistura.AcrescimoValor < 0, "Valor não pode ser menor que zero");
        }

        public void SetProperties(Mistura mistura)
        {
            this.Nome = mistura.Nome.Trim();
            this.AcrescimoValor = mistura.AcrescimoValor;
            this.Data = this.Id != Guid.Empty ? mistura.Data : DateTime.Now;
            this.StatusCardapio = StatusCardapio.ATIVO;
        }

        public void Update(Mistura mistura)
        {
            Validation(mistura);
            SetProperties(mistura);
        }
    }
}