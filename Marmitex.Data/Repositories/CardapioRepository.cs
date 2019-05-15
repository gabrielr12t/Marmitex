using System;
using System.Linq;
using System.Threading.Tasks;
using Marmitex.Data.Context;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marmitex.Data.Repositories
{
    public class CardapioRepository<T> : RepositoryBase<T>, ICardapioRepository<T> where T : Cardapio
    {
        public CardapioRepository(ApplicationDbContext context) : base(context) { }

        public async Task AddCardapio(T t)
        {
            //Cardapio.ValidateEntry(t.Nome); // validando entrada do nome

            var exist = await GetById(t.Id);
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
                if (obj.Equals(typeof(Acompanhamento)))
                {
                    acompanhamento = new Acompanhamento(t.Nome, t.Data);
                    _context.Add(acompanhamento);
                    return;
                }
            }
            //update;

            exist.Nome = t.Nome;
            //_context.Entry(t).State = EntityState.Modified;
        }

    }
}