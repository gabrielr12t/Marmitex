using System;
using Marmitex.Domain.BaseEntity;

namespace Marmitex.Domain.Entidades
{
    public class Acompanhamento : Entity
    {
        public string Nome { get; set; }
        public DateTime Data { get; private set; }

        public Acompanhamento()
        {
            Data = DateTime.Now;
        }
    }
}