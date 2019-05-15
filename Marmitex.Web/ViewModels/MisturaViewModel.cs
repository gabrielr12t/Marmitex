using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Marmitex.Domain.Entidades;

namespace Marmitex.Web.ViewModels
{
    public class MisturaViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Insira o nome da mistura")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo de 3 letras"), MaxLength(25, ErrorMessage = "Tamanho máximo de 25 letras")]
        public string Nome { get; set; }

        public DateTime Data { get; set; }
        // [DataType(DataType.Currency)]
        // [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public decimal? AcrescimoValor { get; set; } // exemplo feijoada
        public IEnumerable<MisturaViewModel> Misturas { get; set; }

        public MisturaViewModel()
        {
            Misturas = new List<MisturaViewModel>();
        }
    }
}