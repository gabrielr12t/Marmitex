using System;
using Marmitex.Domain.BaseEntity;

namespace Marmitex.Domain.Entidades
{
    public class Acompanhamento : Cardapio
    {
        public Acompanhamento()
        {

        }
        public Acompanhamento(string nome, DateTime data)
        {
            SetProperties(nome, data);
        }

        private void SetProperties(string nome, DateTime data)
        {
            this.Nome = nome;
            this.Data = this.Id > 0 ? data : DateTime.Now;
        }

        public void Update(string nome, decimal acrescimoValor, DateTime data)
        {
            SetProperties(nome, data);
        }
    }
}