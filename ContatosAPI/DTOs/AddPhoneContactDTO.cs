using System.ComponentModel.DataAnnotations;

namespace ContatosAPI.DTOs
{
    public class AddPhoneContactDTO
    {
        [MaxLength(11, ErrorMessage = "Número de telefone deve conter no máximo 11 caracteres.")]
        [MinLength(10, ErrorMessage = "Número de telefone deve conter no mínimo 10 caracteres.")]
        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsWhatsapp { get; set; }

        [Required(ErrorMessage = "PersonId é obrigatório")]
        public Guid PersonId { get; set; }
    }
}
