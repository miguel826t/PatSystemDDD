using PatSystem.Domain.Entities.Curriculo;
using PatSystem.Domain.Entities.Curriculo.Cursos;
using System.Collections.Generic;


namespace PatSystem.UI.ViewModels
{
    public class CRdetailsViewModel
    {
        public Curriculo Curriculo { get; set; }
        public Cliente Cliente { get; set; }

        public CursoSuperior CursoSuperior { get; set; }
        public List<CursoSuperior> CursosSuperior { get; set; }

        public CursoTecnico CursoTecnico { get; set; }
        public List<CursoTecnico> CursosTecnico { get; set; }

        public Experiencia Experiencia { get; set; }
        public List<Experiencia> Experiencias { get; set; }

        public Idioma Idioma { get; set; }
        public List<Idioma> Idiomas { get; set; }
    }
}
