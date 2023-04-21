using System.ComponentModel.DataAnnotations;

namespace ContatosAPI.DTOs
{
    public class AddPersonDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Name deve conter no máximo 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sobrenome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Sobrenome deve conter no máximo 100 caracteres.")]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(11, ErrorMessage = "CPF deve conter 11 caracteres númericos.")]
        [MinLength(11, ErrorMessage = "CPF deve conter 11 caracteres númericos.")]
        public string Cpf { get; set; } = string.Empty;
    }
}
