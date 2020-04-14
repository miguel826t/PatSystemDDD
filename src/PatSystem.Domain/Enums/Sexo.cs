using System.ComponentModel.DataAnnotations;

namespace PatSystem.Domain.Enums
{
    public enum Sexo : int
    {
        [Display(Name = "")]
        ND = 0,
        [Display(Name = "Homem")]
        Homem = 1,
        [Display(Name = "Mulher")]
        Mulher = 2
    }
}
