using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Marmitex.Domain.Enums
{
    public enum Status
    {
        [Display(Name = "em andamento")]
        andamento = 0,
        [Display(Name = "em rota de entrega")]
        rota = 1,
        [Display(Name = "entregue")]
        entregue = 2,
        [Display(Name = "cancelado")]
        cancelado = 3,
    }
}