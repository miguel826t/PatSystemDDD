using System.ComponentModel.DataAnnotations;

namespace PatSystem.Domain.Entities.SegDesemprego
{
    public class Seguro : BaseEntity
    {
        [Required(ErrorMessage = "{0} é Obrigatório")]
        public double SeguroId { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        [Display(Name = "Requerimento Atual")]
        public string CodSeguro { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        [Display(Name = "Data do Seguro")]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        [Display(Name = "CBO da Profissão")]
        public int CodCboid { get; set; }
        public Cbo CodCbo { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        [Display(Name = "CNPJ da Empresa")]
        public string EmpresaId { get; set; }
        public Empresa Cnpj { get; set; }


    }
}
