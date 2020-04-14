using PatSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PatSystem.Domain.Entities.SegDesemprego
{
    public class Cbo : BaseEntity
    {
        [Required(ErrorMessage = "{0} é Obrigatório")]
        public int CodCboId { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter de {2} a {1} caracteres")]
        public string Desc { get; set; }
    }
}
