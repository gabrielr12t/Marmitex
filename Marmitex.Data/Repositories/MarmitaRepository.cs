using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Enums;
using Marmitex.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Marmitex.Data.Repositories
{
    public class MarmitaRepository : RepositoryBase<Marmita>, IMarmitaRepository
    {
        private readonly IClienteRepository _clienterepository;

        public MarmitaRepository(ApplicationDbContext context, IClienteRepository clienterepository) : base(context) { _clienterepository = clienterepository; }

        public async Task FinalizandoPedido(List<Marmita> marmitas, Cliente cliente, Pedido pedido)
        {
            try
            {
                Marmita marmita = null;

                cliente = await _clienterepository.GetById(cliente.Id);//verificar se cliente existe
                //verificar se mistura existe
                //verificar se salada existe
                //..........

                //criando Pedido
                await _context.Pedidos.AddAsync(pedido = new Pedido(marmitas.Sum(t => t.Valor), cliente, marmitas,
                   OpcoesDeEntrega.Entregar, OpcoesDePagamento.Dinheiro));

                //adicionando marmitas ao pedido
                foreach (var m in marmitas)
                {
                    //marmita
                    await Add(marmita = new Marmita(m.Mistura, m.Valor, m.Salada, m.Tamanho, m.Mistura.AcrescimoValor,
                    m.Observacao, m.Acompanhamentos, cliente, pedido));

                    //marmita acompanhamento                     
                    foreach (var acompanhamento in m.Acompanhamentos)
                    {
                        await _context.MarmitaAcompanhamentos.AddAsync(new MarmitaAcompanhamento(marmita, acompanhamento));
                    }
                }         
                await Save();        
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao finalizar pedido: " + e.Message);
            }
        }
    }
}