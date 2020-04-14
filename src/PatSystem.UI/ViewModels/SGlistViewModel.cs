using System.ComponentModel.DataAnnotations;

namespace PatSystem.UI.ViewModels
{
    public class SGlistViewModel
    {
        [Display(Name = "Id")]
        public int SeguroId { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        [Display(Name = "Empresa")]
        public string Empresa { get; set; }

        [Display(Name = "Segmento")]
        public string Segmento { get; set; }
    }
}
