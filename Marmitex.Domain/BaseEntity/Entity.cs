using System.ComponentModel.DataAnnotations;

namespace Marmitex.Domain.BaseEntity
{
    public class Entity
    {
        [Key]
        public long Id { get; set; }
    }
}