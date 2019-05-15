using System;
using Marmitex.Domain.DomainExceptions;
using Marmitex.Domain.Enums;

namespace Marmitex.Domain.BaseEntity
{
    public class Cardapio : Entity
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public StatusCardapio StatusCardapio { get; set; }

        public static void ValidateEntry(string Nome)
        {
            ExceptionClass.Exec(string.IsNullOrEmpty(Nome), "Nome não pode ser vazio");
            ExceptionClass.Exec(Nome.Length < 3, "Nome não pode ter menos que 3 caracteres");
            ExceptionClass.Exec(Nome.Length > 30, "Nome não pode ter mais que 30 caracteres");
        }
    }
}