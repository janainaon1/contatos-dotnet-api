using System.ComponentModel.DataAnnotations;

namespace ContatosAPI.DTOs
{
    public class AddEmailContactDTO
    {
        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [MaxLength(100, ErrorMessage = "E-mail deve conter no máximo 100 caracteres.")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "PersonId é obrigatório.")]
        public Guid PersonId { get; set; }
    }
}
