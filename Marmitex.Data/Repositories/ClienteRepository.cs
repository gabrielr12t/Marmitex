using System;
using System.Linq;
using System.Threading.Tasks;
using Marmitex.Data.Context;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marmitex.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context) { }
        public override async Task Add(Cliente obj)
        {
            var cliente = await GetById(obj.Id);

            if (cliente == null)
            {
                //create
                cliente = new Cliente(obj.Nome, obj.Sexo, obj.Cep, obj.Rua,
                obj.RuaNumero, obj.Bairro, obj.NumeroCasa, obj.Telefone, obj.Celular, DateTime.Now);
                _context.Clientes.Add(cliente);
                return;
            }
            //update                
            cliente.Update(obj.Nome, obj.Sexo, obj.Cep, obj.Rua, obj.RuaNumero, obj.Bairro, obj.NumeroCasa,
            obj.Telefone, obj.Celular, cliente.DataCadastro);
            //_context.Clientes.Update(cliente);
        }

        public IQueryable<Pedido> ClientePedidos(int id)
        {
            var query = _context.Set<Pedido>().Include(p => p.Cliente).Where(c => c.Cliente.Id == id);
            return query.Any() ? query : null;
        }

        public async Task<Cliente> GetClienteByTelefone(string telefone)
        {
            bool isCelular = telefone != null && telefone.Length == 15;
            bool isTelefone = telefone != null && telefone.Length == 14;
            bool telefoneIsValid = !string.IsNullOrEmpty(telefone) && (isCelular || isTelefone);

            var cliente = telefoneIsValid ? await GetOneWithPredicate(c => c.Telefone.Equals(telefone.Trim()) || c.Celular.Equals(telefone.Trim())) : null;

            if (cliente == null)
            {
                cliente = new Cliente();
                cliente.Celular = isCelular ? telefone : null;
                cliente.Telefone = isTelefone ? telefone : null;
            }
            return cliente;
        }
    }
}