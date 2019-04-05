using System;

namespace Marmitex.Domain.BaseEntity
{
    public class Cardapio : Entity
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }
    }
}