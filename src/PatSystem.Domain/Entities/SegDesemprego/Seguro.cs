using PatSystem.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PatSystem.Domain.Entities.SegDesemprego
{
    public class Seguro : BaseEntity
    {
        [Required(ErrorMessage = "{0} é Obrigatório")]
        public double SeguroId { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        public string CodSeguro { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        public int CodCboid { get; set; }
        public Cbo CodCbo { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        public string EmpresaId { get; set; }
        public Empresa Cnpj { get; set; }


    }
}
