using System;

namespace PatSystem.Domain.Entities.Curriculo
{
    public class Curriculo : BaseEntity
    {
        public int CurriculoID { get; set; }

        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }

        public DateTime DataCriacao { get; set; }
        public string CursoSuperiorSN { get; set; }
        public string CursoTecnicoSN { get; set; }
        public string IdiomaSN { get; set; }
        public string ExperienciaSN { get; set; }

    }
}
