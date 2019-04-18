using System;
using Marmitex.Domain.Enums;

namespace Marmitex.Domain.BaseEntity
{
    public class Cardapio : Entity
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public StatusCardapio StatusCardapio { get; set; }
    }
}