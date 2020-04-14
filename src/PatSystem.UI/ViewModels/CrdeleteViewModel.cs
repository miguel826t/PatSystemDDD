using System.ComponentModel.DataAnnotations;

namespace PatSystem.UI.ViewModels
{
    public class CrDeleteViewModel
    {
        [Display(Name = "Código do Curriculo")]
        public int CurriculoID { get; set; }

        [Display(Name = "Código do Cliente")]
        public int ClienteId { get; set; }

        public string Nome { get; set; }
    }
}
