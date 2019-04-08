using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Marmitex.Domain.Enums;

namespace Marmitex.Web.ViewModels
{
    public class MarmitaViewModel
    {
        public long Id { get; set; }

        public int SaladaId { get; set; }
        // public virtual SaladaViewModel Salada { get; set; }

        public decimal Valor { get; private set; }

        public char TamanhoId { get; set; }
        // public virtual Tamanho Tamanho { get; set; }


        public int MisturaId { get; set; }
        // public virtual MisturaViewModel Mistura { get; set; }

        public string Observacao { get; set; }

        // listas

        public virtual IEnumerable<AcompanhamentoViewModel> Acompanhamentos { get; set; }
        public virtual IEnumerable<SaladaViewModel> Saladas { get; set; }
        public virtual IEnumerable<MisturaViewModel> Misturas { get; set; }
        public virtual IEnumerable<Tamanho> Tamanhos { get; set; }


        public List<MarmitaViewModel> Marmitas { get; set; }
        public MarmitaViewModel()
        {
            Acompanhamentos = new List<AcompanhamentoViewModel>();
            Saladas = new List<SaladaViewModel>();
            Misturas = new List<MisturaViewModel>();
            // Marmitas =as Enumerable<MarmitaViewModel>().AsQueryable();
        }
    }
}