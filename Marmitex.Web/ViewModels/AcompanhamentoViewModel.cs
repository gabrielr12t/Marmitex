using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marmitex.Web.ViewModels
{
    public class AcompanhamentoViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Insira o nome do acompanhamento")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo de 3 letras"), MaxLength(30, ErrorMessage = "Tamanho máximo de 30 letras")]
        public string Nome { get; set; }

        public DateTime Data { get; set; }

        public IEnumerable<AcompanhamentoViewModel> Acompanhamentos { get; set; }

        public AcompanhamentoViewModel()
        {
            Acompanhamentos = new List<AcompanhamentoViewModel>();
        }
    }
}