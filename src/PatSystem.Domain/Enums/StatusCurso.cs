using System.ComponentModel.DataAnnotations;

namespace PatSystem.Domain.Enums
{
    public enum StatusCurso : int
    {
        [Display(Name = "Não Cursa")]
        NaoCursa = 0,
        [Display(Name = "Está Cursando")]
        Cursando = 1,
        [Display(Name = "Concluído")]
        Concluido = 2
    }
}
