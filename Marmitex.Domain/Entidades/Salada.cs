using System;
using Marmitex.Domain.BaseEntity;

namespace Marmitex.Domain.Entidades
{
    public class Salada : Entity
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public Salada()
        {
            Data = DateTime.Now;
        }
    }
}