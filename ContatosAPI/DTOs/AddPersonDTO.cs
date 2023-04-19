using System.ComponentModel.DataAnnotations;

namespace ContatosAPI.DTOs
{
    public class AddPersonDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        [MaxLength(200)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(11, ErrorMessage = "CPF máximo de 11 caracteres")]
        [MinLength(11, ErrorMessage = "CPF mínimo de 11 caracteres")]
        public string Cpf { get; set; } = string.Empty;
    }
}
