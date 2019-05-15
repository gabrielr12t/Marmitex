using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;

namespace Marmitex.Domain.Entidades
{
    public class MarmitaAcompanhamento : Entity
    {
        public Marmita Marmita { get; set; }
        public long MarmitaId { get; set; }
        public Acompanhamento Acompanhamento { get; set; }
        public long AcompanhamentoId { get; set; }

        public MarmitaAcompanhamento() { }

        public MarmitaAcompanhamento(Marmita marmita, Acompanhamento acompanhamento)
        {
            ValidateProperties(marmita, acompanhamento);
            SetProperties(marmita, acompanhamento);
        }
        private void ValidateProperties(Marmita marmita, Acompanhamento acompanhamento)
        {
            ExceptionClass.Exec(marmita == null, "Marmita inválida");
            ExceptionClass.Exec(acompanhamento == null, "Acompanhamento é obrigatório");
        }

        private void SetProperties(Marmita marmita, Acompanhamento acompanhamento)
        {
            this.MarmitaId = marmita.Id;
            this.AcompanhamentoId = acompanhamento.Id;
        }
    }
}