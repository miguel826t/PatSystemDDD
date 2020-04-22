using System.ComponentModel.DataAnnotations;

namespace PatSystem.UI.ViewModels
{
    public class SegListViewModel
    {

        [Display(Name = "Id")]
        public double SegId { get; set; }

        [Display(Name = "Requerimento")]
        public string CodSeguro { get; set; }

        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        [Display(Name = "Empresa")]
        public string Empresa { get; set; }

        public string Segmento { get; set; }

    }
}
