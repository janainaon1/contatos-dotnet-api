using System.ComponentModel.DataAnnotations;

namespace ContatosAPI.DTOs
{
    public class PersonDTO
    {
        [Required(ErrorMessage = "Id é obrigatório.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Nome deve conter no máximo 100 caracteres númericos.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sobrenome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Sobrenome deve conter no máximo 100 caracteres númericos.")]
        public string LastName { get; set; } = string.Empty;

        [MinLength(11, ErrorMessage = "CPF deve conter 11 caracteres númericos.")]
        [MaxLength(11, ErrorMessage = "CPF deve conter 11 caracteres númericos.")]
        public string Cpf { get; set; } = string.Empty;
    }
}
