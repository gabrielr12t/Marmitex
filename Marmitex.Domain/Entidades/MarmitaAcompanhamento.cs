using System;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Interfaces.ModelsInterfaces;

namespace Marmitex.Domain.Entidades
{
    public class MarmitaAcompanhamento : IModelBase<MarmitaAcompanhamento>
    {
        public Guid Id { get; set; }
        public Marmita Marmita { get; set; }
        public Acompanhamento Acompanhamento { get; set; }
        public long AcompanhamentoId { get; set; }

        public MarmitaAcompanhamento() { }

        public MarmitaAcompanhamento(MarmitaAcompanhamento marmita)
        {
            Validation(marmita);
            SetProperties(marmita);
        }
        public void Validation(MarmitaAcompanhamento marmita)
        {
            ExceptionClass.Exec(marmita == null, "Marmita inválida");
            ExceptionClass.Exec(marmita.AcompanhamentoId == 0, "Acompanhamento é obrigatório");
        }

        public void SetProperties(MarmitaAcompanhamento marmita)
        {
            this.Id = marmita.Id;
            this.AcompanhamentoId = marmita.AcompanhamentoId;
        }
    }
}