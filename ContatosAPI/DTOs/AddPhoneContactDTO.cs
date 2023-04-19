using System.ComponentModel.DataAnnotations;

namespace ContatosAPI.DTOs
{
    public class AddPhoneContactDTO
    {
        [Required(ErrorMessage = "Número de telefone é obrigatório")]
        [MaxLength(200)]
        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsWhatsapp { get; set; } = false;

        [Required(ErrorMessage = "PersonId é obrigatório")]
        public Guid PersonId { get; set; }
    }
}
