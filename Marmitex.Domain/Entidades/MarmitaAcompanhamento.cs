using Marmitex.Domain.BaseEntity;

namespace Marmitex.Domain.Entidades
{
    public class MarmitaAcompanhamento : Entity
    {
        public Marmita Marmita { get; set; }
        public Acompanhamento Acompanhamento { get; set; }
    }
}