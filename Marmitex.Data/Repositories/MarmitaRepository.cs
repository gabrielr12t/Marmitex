using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Marmitex.Data.Repositories
{
    public class MarmitaRepository : RepositoryBase<Marmita>, IMarmitaRepository
    {

        public MarmitaRepository(ApplicationDbContext context) : base(context) { }
        public async Task FinalizandoPedido(List<Marmita> marmitas, Cliente cliente, Pedido pedido)
        {
            try
            {
                Marmita marmita;

                //criando pedido                      
                await _context.Pedidos.AddAsync(pedido = new Pedido(marmitas.Sum(t => t.Valor), cliente, marmitas,
                    Domain.Enums.OpcoesDeEntrega.Entregar, Domain.Enums.OpcoesDePagamento.Dinheiro));

                //adicionando marmitas ao pedido
                foreach (var m in marmitas)
                {
                    //marmita
                    await Add(marmita = new Marmita(m.Mistura.Id, m.Valor, m.Salada.Id, m.Tamanho, m.Mistura.AcrescimoValor,
                    m.Observacao, m.Acompanhamentos, cliente, pedido));

                    //itens do pedido
                    await _context.ItensPedidos.AddAsync(new ItensPedido(pedido, marmita));

                    //marmita acompanhamento                     
                    foreach (var acompanhamento in m.Acompanhamentos)
                    {
                        //await _context.MarmitaAcompanhamentos.AddAsync(new MarmitaAcompanhamento(marmita, acompanhamento));
                    }
                }
            }
            catch (System.Exception)
            {
                throw new Exception("Erro ao finalizar pedido");
            }
        }
    }
}