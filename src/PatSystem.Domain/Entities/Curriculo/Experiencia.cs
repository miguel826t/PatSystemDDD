using System.ComponentModel.DataAnnotations;

namespace PatSystem.Domain.Entities.Curriculo
{
    public class Experiencia : BaseEntity
    {
        public int ExperienciaId { get; set; }
        [Display(Name = "Nome da Empresa")]
        public string NomeEmpresa { get; set; }
        [Display(Name = "Último Cargo")]
        public string UltimoCargo { get; set; }
        [Display(Name = "Anos de Experiência")]
        public double? Anos { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public int CurriculoID { get; set; }
        public Curriculo Curriculo { get; set; }
    }
}
