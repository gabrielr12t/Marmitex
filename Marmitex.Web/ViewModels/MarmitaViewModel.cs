using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Enums;

namespace Marmitex.Web.ViewModels
{
    public class MarmitaViewModel
    {
        public long Id { get; set; }

        [StringLength(15, ErrorMessage = "Tamanho inválido"), MinLength(14, ErrorMessage = "Tamanho inválido")]
        [Required(ErrorMessage = "Insira um telefone para contato")]
        public string Numero { get; set; }

        public int SaladaId { get; set; }
        public virtual SaladaViewModel Salada { get; set; }

        public decimal Valor { get; private set; }

        public char TamanhoId { get; set; }
        // public virtual Tamanho Tamanho { get; set; }
        public Tamanho Tamanho { get; set; }

        public int MisturaId { get; set; }

        [Required(ErrorMessage = "Selecione uma mistura")]
        public virtual MisturaViewModel Mistura { get; set; }

        public string Observacao { get; set; }

        public Cliente Cliente { get; set; }

        // listas

        public virtual ICollection<MarmitaAcompanhamentoViewModel> MarmitaAcompanhamentos { get; set; }
        public virtual ICollection<AcompanhamentoViewModel> Acompanhamentos { get; set; }
        public int[] AcompanhamentosInt { get; set; }
        public virtual IEnumerable<SaladaViewModel> Saladas { get; set; }
        public virtual IEnumerable<MisturaViewModel> Misturas { get; set; }
        public virtual IEnumerable<Tamanho> Tamanhos { get; set; }


        public List<MarmitaViewModel> Marmitas { get; set; }
        public MarmitaViewModel()
        {
            AcompanhamentosInt = new int[2];
            Acompanhamentos = new List<AcompanhamentoViewModel>();
            Saladas = new List<SaladaViewModel>();
            Misturas = new List<MisturaViewModel>();
            Cliente = new Cliente();
            // Marmitas =as Enumerable<MarmitaViewModel>().AsQueryable();
        }
    }
}