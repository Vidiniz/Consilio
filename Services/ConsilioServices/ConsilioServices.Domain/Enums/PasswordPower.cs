using System.ComponentModel.DataAnnotations;

namespace ConsilioServices.Domain.Enums
{
    public enum PasswordPower
    {
        [Display(Name = "Muito Fraca")]
        MuitoFraca = 1,

        [Display(Name = "Fraca")]
        Fraca      = 2,

        [Display(Name = "Aceitavel")]
        Aceitavel  = 3,

        [Display(Name = "Forte")]
        Forte      = 4,

        [Display(Name = "Muito Forte")]
        MuitoForte = 5
    }
}
