using PatSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PatSystem.Domain.Entities.SegDesemprego
{
    public class Empresa : BaseEntity
    {
        [Required(ErrorMessage = "{0} é Obrigatório")]
        public string EmpresaId { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter de {2} a {1} caracteres")]
        [Required(ErrorMessage = "{0} é Obrigatório")]
        public string Nome { get; set; }

        public string Segmento { get; set; }


    }
}
