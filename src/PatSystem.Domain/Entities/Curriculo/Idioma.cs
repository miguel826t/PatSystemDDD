using PatSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PatSystem.Domain.Entities.Curriculo
{
    public class Idioma : BaseEntity
    {
        public int IdiomaId { get; set; }
        public Linguas Nome { get; set; }
        [Display(Name = "Instituição")]
        public string Instituicao { get; set; }
        [Display(Name = "Nivel de Fluência")]
        public LevelSpeak NivelFluencia { get; set; }
        [Display(Name = "Anos Cursados")]
        public int? AnosCursados { get; set; }

        public int CurriculoID { get; set; }
        public Curriculo Curriculo { get; set; }
    }
}
