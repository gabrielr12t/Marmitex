using System;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Enums;
using Marmitex.Domain.Interfaces.ModelsInterfaces;

namespace Marmitex.Domain.Entidades
{
    public class Cliente : IModelBase<Cliente>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int RuaNumero { get; set; }
        public string Bairro { get; set; }
        public string NumeroCasa { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public DateTime DataCadastro { get; set; }


        public Cliente() { }
        public Cliente(Cliente cliente)
        {
            Validation(cliente);
            SetProperties(cliente);
        }
        public void Update(Cliente cliente)
        {
            SetProperties(cliente);
        }

        public void Validation(Cliente cliente)
        {
            ExceptionClass.Exec(string.IsNullOrEmpty(cliente.Nome), "Campo nome é obrigatório");
            ExceptionClass.Exec(string.IsNullOrEmpty(cliente.Sexo.ToString()), "Escolha uma opção de sexo");
            ExceptionClass.Exec(string.IsNullOrEmpty(cliente.Rua), "O campo rua é obrigatório");
            ExceptionClass.Exec(cliente.RuaNumero <= 0, "O campo número da rua é obrigatório");
            ExceptionClass.Exec(string.IsNullOrEmpty(cliente.Bairro), "O campo bairro é obrigatório");
            ExceptionClass.Exec(string.IsNullOrEmpty(cliente.NumeroCasa), "O campo número da casa é obrigatório");
            ExceptionClass.Exec(string.IsNullOrEmpty(cliente.Telefone), "O campo telefone é obrigatório");
            ExceptionClass.Exec(cliente.Telefone.Length != 14, "Telefone inválido");

            if (cliente.Celular != null && cliente.Celular.Length > 0)
                ExceptionClass.Exec(cliente.Celular.Length != 15, "Celular inválido");
        }

        public void SetProperties(Cliente cliente)
        {
            this.DataCadastro = cliente.DataCadastro;
            if (this.Id == Guid.Empty)
                DataCadastro = DateTime.Now;

            this.Nome = cliente.Nome.Trim();
            this.Sexo = cliente.Sexo;
            this.Cep = !string.IsNullOrEmpty(cliente.Cep) ? cliente.Cep : null;
            this.Rua = cliente.Rua.Trim();
            this.RuaNumero = cliente.RuaNumero != 0 ? cliente.RuaNumero : 0;
            this.Bairro = cliente.Bairro.Trim();
            this.NumeroCasa = cliente.NumeroCasa.Trim();
            this.Telefone = cliente.Telefone.Trim();
            this.Celular = !string.IsNullOrEmpty(cliente.Celular) ? cliente.Celular : null;
        }
    }
}