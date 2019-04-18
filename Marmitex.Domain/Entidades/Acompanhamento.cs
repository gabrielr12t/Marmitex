using System;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.Enums;

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
            this.StatusCardapio = StatusCardapio.ATIVO;
        }

        public void Update(string nome, decimal acrescimoValor, DateTime data)
        {
            SetProperties(nome, data);
        }
    }
}