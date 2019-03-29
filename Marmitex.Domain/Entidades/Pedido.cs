using System;
using Marmitex.Domain.BaseEntity;

namespace Marmitex.Domain.Entidades
{
    public class Pedido : Entity
    {
        public DateTime Data { get; private set; }
        public decimal Total { get; set; }
        public virtual Cliente Cliente { get; set; }

        public Pedido()
        {
            Data = DateTime.Now;
        }
    }
}