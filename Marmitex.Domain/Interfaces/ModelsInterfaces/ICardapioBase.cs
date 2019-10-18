using System;
using Marmitex.Domain.Enums;

namespace Marmitex.Domain.Interfaces.ModelsInterfaces
{
    public interface ICardapioBase
    {
        string Nome { get; set; }
        DateTime Data { get; set; }
        StatusCardapio StatusCardapio { get; set; }
    }
}