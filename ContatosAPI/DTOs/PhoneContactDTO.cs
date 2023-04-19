using System.ComponentModel.DataAnnotations;

namespace ContatosAPI.DTOs
{
    public class PhoneContactDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public bool IsWhatsapp { get; set; }

        [Required]
        public Guid PersonId { get; set; }
    }
}
