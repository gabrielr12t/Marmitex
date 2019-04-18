using System;
using System.Collections.Generic;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Enums;

namespace Marmitex.Web.ViewModels
{
    public class ItensDoPedido
    {
        public int misturaId { get; set; }
        public string mistura { get; set; }
        public List<Acompanhamento> acompanhamentos { get; set; }
        public int salada { get; set; }
        public Tamanho tamanho { get; set; }
        public string observacao { get; set; }
    }

    public class Acompanhamentos
    {
        public int id { get; set; }
        public string nome { get; set; }
    }
}