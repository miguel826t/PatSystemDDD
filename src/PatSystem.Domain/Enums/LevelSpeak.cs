using System.ComponentModel.DataAnnotations;

namespace PatSystem.Domain.Enums
{
    public enum LevelSpeak : int
    {
        [Display(Name = "Não Possui")]
        Nao = 0,
        Basico = 1,
        [Display(Name = "Médio")]
        Medio = 2,
        Fluente = 3
    }
}
