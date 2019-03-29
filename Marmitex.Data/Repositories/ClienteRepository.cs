using System;
using System.Linq;
using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marmitex.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context) { }

        // Registro de cliente


        public override void Add(Cliente obj)
        {

            var cliente = GetById(obj.Id);
            if (cliente != null)
            {
                //Update                
                cliente.Update(obj.Id, obj.Nome, obj.Sobrenome, obj.Sexo, obj.Cep, obj.Rua, obj.RuaNumero, obj.Bairro, obj.NumeroCasa, obj.Telefone, obj.Celular, cliente.DataCadastro);
                return;
            }
            //Create
            cliente = new Cliente(obj.Id, obj.Nome, obj.Sobrenome, obj.Sexo, obj.Cep, obj.Rua, obj.RuaNumero, obj.Bairro, obj.NumeroCasa, obj.Telefone, obj.Celular, DateTime.Now);
            _context.Add(cliente);
        }

        public IQueryable<Pedido> ClientePedidos(int id)
        {
            var query = _context.Set<Pedido>().Include(p => p.Cliente).Where(c => c.Cliente.Id == id);
            return query.Any() ? query.AsQueryable() : null;
        }

        public Cliente GetClienteByTelefone(string telefone)
        {
            bool isCelular = telefone.Length == 15;
            bool isTelefone = telefone.Length == 14;
            bool telefoneIsValid = !string.IsNullOrEmpty(telefone) && (isCelular || isTelefone);

            var cliente = telefoneIsValid ? _context.Set<Cliente>().FirstOrDefault(c => c.Telefone.Equals(telefone) || c.Celular.Equals(telefone)) : null;

            if (cliente == null)
            {
                cliente = new Cliente();

                if (isCelular)
                {
                    cliente.Celular = telefone;
                }
                else if (isTelefone)
                {
                    cliente.Telefone = telefone;
                }
                return cliente;
            }
            else
            {
                return cliente;
            }

        }
    }
}