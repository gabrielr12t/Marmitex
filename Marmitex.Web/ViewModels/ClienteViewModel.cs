using System;
using System.ComponentModel.DataAnnotations;
using Marmitex.Domain.BaseEntity;
using Marmitex.Domain.Enums;

namespace Marmitex.Web.ViewModels
{
    public class ClienteViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }


        public string Sobrenome { get; set; }



        [Required(ErrorMessage = "Campo obrigatório")]
        [EnumDataType(typeof(Sexo))]
        public Sexo Sexo { get; set; }

         
        public string Cep { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        public string Rua { get; set; }


        [RegularExpression(@"^[0-9]+", ErrorMessage = "Somente números")]
        public int RuaNumero { get; set; }



        [Required(ErrorMessage = "Campo obrigatório")]
        public string Bairro { get; set; }



        [Required(ErrorMessage = "Campo obrigatório")]
        public string NumeroCasa { get; set; }



        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; }

        public string Celular { get; set; }
    
    }
}