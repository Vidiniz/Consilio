using System.ComponentModel.DataAnnotations;

namespace ConsilioServices.Application.ViewModel.SystemTools
{
    public class SystemProfileViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "Número máximo de caracteres permitido é de {0}")]
        [MinLength(5, ErrorMessage = "Número mínimo de caracteres permitido é de {0}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Campo Admin é obrigatório")]
        public bool HasAdmin { get; set; }
    }
}
