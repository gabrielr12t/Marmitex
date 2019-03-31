using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Marmitex.Domain.Entidades;

namespace Marmitex.Web.ViewModels
{
    public class MisturaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o nome da mistura")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo de 3 letras"), MaxLength(18, ErrorMessage = "Tamanho máximo de 18 letras")]
        public string Nome { get; set; }
        public decimal? AcrescimoValor { get; set; } // exemplo feijoada
        public IQueryable<MisturaViewModel> Misturas { get; set; }
    }
}