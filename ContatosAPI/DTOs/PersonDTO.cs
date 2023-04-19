using ContatosAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ContatosAPI.DTOs
{
    public class PersonDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Cpf { get; set; } = string.Empty;
    }
}
