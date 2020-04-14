using System.ComponentModel.DataAnnotations;

namespace PatSystem.UI.ViewModels
{
    public class CRindexViewModel
    {
        [Display(Name = "Código")]
        public int CurriculoID { get; set; }

        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Display(Name = "Idade")]
        public int Idade { get; set; }

        [Display(Name = "Ensino Médio")]
        public string EnsinoMedio { get; set; }

        [Display(Name = "Área de Atuação")]
        public string AreaAtuacao { get; set; }

        [Display(Name = "Curso Superior")]
        public string CursoSuperiorSN { get; set; }

        [Display(Name = "Curso Tecnico")]
        public string CursoTecnicoSN { get; set; }

        [Display(Name = "Idiomas")]
        public string IdiomaSN { get; set; }   

        [Display(Name = "Experiencia")]
        public string ExperienciaSN { get; set; }

    }
}
