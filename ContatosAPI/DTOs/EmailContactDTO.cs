using System.ComponentModel.DataAnnotations;

namespace ContatosAPI.DTOs
{
    public class EmailContactDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        public Guid PersonId { get; set; }
    }
}
