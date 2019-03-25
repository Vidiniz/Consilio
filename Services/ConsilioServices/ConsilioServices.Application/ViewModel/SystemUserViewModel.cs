using System.ComponentModel.DataAnnotations;

namespace ConsilioServices.Application.ViewModel
{
    public class SystemUserViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "Número máximo de caracteres permitido é de {0}")]
        [MinLength(5, ErrorMessage = "Número mínimo de caracteres permitido é de {0}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo Sobrenome é obrigatório")]
        [MaxLength(100, ErrorMessage = "Número máximo de caracteres permitido é de {0}")]
        [MinLength(5, ErrorMessage = "Número mínimo de caracteres permitido é de {0}")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Campo Email é obrigatório")]
        [MaxLength(200, ErrorMessage = "Número máximo de caracteres permitido é de {0}")]
        [MinLength(5, ErrorMessage = "Número mínimo de caracteres permitido é de {0}")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Password é obrigatório")]
        [MaxLength(20, ErrorMessage = "Número máximo de caracteres permitido é de {0}")]
        [MinLength(5, ErrorMessage = "Número mínimo de caracteres permitido é de {0}")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo Status é obrigatório")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Campo Perfil é obrigatório")]
        public int SystemProfileId { get; set; }

        public SystemProfileViewModel SystemProfile { get; set; }
    }
}
