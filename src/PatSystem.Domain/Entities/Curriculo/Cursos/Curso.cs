using PatSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PatSystem.Domain.Entities.Curriculo.Cursos
{
    public class Curso : BaseEntity
    {
        public int CurriculoID { get; set; }
        public Curriculo Curriculo { get; set; }
        public string Nome { get; set; }
        public string Modalidade { get; set; }
        [Display(Name = "Instituição")]
        public string Instituicao { get; set; }
        public string Tipo { get; set; }
        public StatusCurso Status { get; set; }
    }
}
