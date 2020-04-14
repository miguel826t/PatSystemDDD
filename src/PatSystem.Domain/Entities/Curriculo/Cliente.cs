using PatSystem.Domain.Entities;
using PatSystem.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PatSystem.Domain.Entities.Curriculo
{
    public class Cliente : BaseEntity
    {
        public int ClienteId { get; set; }

        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} deve ter de {2} a {1} caracteres")]
        [Required(ErrorMessage = "{0} é Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        [Display(Name = "Tl. Fixo")]
        [Required(ErrorMessage = "{0} é Obrigatório")]
        public string TlFixo { get; set; }


        [Required(ErrorMessage = "{0} é Obrigatório")]
        [Display(Name = "Celular")]
        public string TlMovel { get; set; }

        [EmailAddress(ErrorMessage = "Insira um E-mail valido")]
        [Required(ErrorMessage = "{0} é Obrigatório")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} deve ter de {2} a {1} caracteres")]
        [Display(Name = "Área de Atuação")]
        public string AreaAtuacao { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        [Display(Name = "Ensino Médio")]
        public string EnsinoMedio { get; set; }

        public int Idade { get; set; }

        public Sexo Sexo { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        public string UF { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} deve ter de {2} a {1} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} deve ter de {2} a {1} caracteres")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatório")]
        public int Numero { get; set; }

        

        public void CalcIdade()
        {
            Idade = DateTime.Now.Year - Nascimento.Year;
        }
    }
}
