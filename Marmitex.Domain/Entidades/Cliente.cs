using System;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Enums;

namespace Marmitex.Domain.Entidades
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Sexo Sexo { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int RuaNumero { get; set; }
        public string Bairro { get; set; }
        public string NumeroCasa { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public DateTime DataCadastro { get; private set; }

        public Cliente() { }
        public Cliente(long id, string nome, string sobrenome, Sexo sexo, string cep, string rua, int ruaNumero, string bairro, string numeroCasa, string telefone, string celular, DateTime dataCadastro)
        {
            ValidationProperties(nome, sobrenome, sexo, cep, rua, ruaNumero, bairro, numeroCasa, telefone, celular);
            SetProperties(id, nome, sobrenome, sexo, cep, rua, ruaNumero, bairro, numeroCasa, telefone, celular, dataCadastro);
        }
        public void Update(long id, string nome, string sobrenome, Sexo sexo, string cep, string rua, int ruaNumero, string bairro, string numeroCasa, string telefone, string celular, DateTime dataCadastro)
        {
            SetProperties(id, nome, sobrenome, sexo, cep, rua, ruaNumero, bairro, numeroCasa, telefone, celular, dataCadastro);
        }
        private void ValidationProperties(string nome, string sobrenome, Sexo sexo, string cep, string rua, int ruaNumero, string bairro, string numeroCasa, string telefone, string celular)
        {
            ExceptionClass.Exec(string.IsNullOrEmpty(nome), "Campo nome é obrigatório");
            ExceptionClass.Exec(string.IsNullOrEmpty(sexo.ToString()), "Escolha uma opção de sexo");
            ExceptionClass.Exec(string.IsNullOrEmpty(rua), "O campo rua é obrigatório");
            ExceptionClass.Exec(ruaNumero <= 0, "O campo número da rua é obrigatório");
            ExceptionClass.Exec(string.IsNullOrEmpty(bairro), "O campo bairro é obrigatório");
            ExceptionClass.Exec(string.IsNullOrEmpty(numeroCasa), "O campo número da casa é obrigatório");
            ExceptionClass.Exec(string.IsNullOrEmpty(telefone), "O campo telefone é obrigatório");
            ExceptionClass.Exec(telefone.Length != 14, "Telefone inválido");
            if (celular != null && celular.Length > 0) ExceptionClass.Exec(celular.Length != 15, "Celular inválido");
        }

        private void SetProperties(long id, string nome, string sobrenome, Sexo sexo, string cep, string rua, int ruaNumero, string bairro, string numeroCasa, string telefone, string celular, DateTime dataCadastro)
        {
            this.DataCadastro = dataCadastro;
            if (id == 0) DataCadastro = DateTime.Now;
            this.Id = id;
            this.Nome = nome.Trim();
            this.Sobrenome = !string.IsNullOrEmpty(sobrenome) ? sobrenome.Trim() : null;
            this.Sexo = sexo;
            this.Cep = !string.IsNullOrEmpty(cep) ? cep : null;
            this.Rua = rua.Trim();
            this.RuaNumero = ruaNumero != 0 ? ruaNumero : 0;
            this.Bairro = bairro.Trim();
            this.NumeroCasa = numeroCasa.Trim();
            this.Telefone = telefone.Trim();
            this.Celular = !string.IsNullOrEmpty(celular) ? celular : null;
        }
    }
}