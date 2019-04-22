using System;
using System.Linq;
using System.Threading.Tasks;
using Marmitex.Data.Context;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marmitex.Data.Repositories
{
    public class CardapioRepository<T> : RepositoryBase<T>, ICardapioRepository<T> where T : Cardapio
    {
        public CardapioRepository(ApplicationDbContext context) : base(context) { }
        public void AddCardapio(T t)
        {
            var exist = GetById(t.Id);
            var obj = typeof(T);
            Salada salada = null;
            Acompanhamento acompanhamento = null;
            if (exist == null)
            {
                if (obj.Equals(typeof(Salada)))
                {
                    salada = new Salada(t.Nome, t.Data);
                    _context.Add(salada);
                    return;
                }
                if (obj.GetType().Equals(typeof(Acompanhamento)))
                {
                    acompanhamento = new Acompanhamento(t.Nome, t.Data);
                    _context.Add(acompanhamento);
                    return;
                }
            }
            //update;
            exist.Nome = t.Nome;
        }

    }
}