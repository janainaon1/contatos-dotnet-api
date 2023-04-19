using ContatosAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ContatosAPI.DTOs
{
    public class PersonDetailsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;

        public IEnumerable<PhoneContactDTO>? PhoneContacts { get; set; }
        public IEnumerable<EmailContactDTO>? EmailContacts { get; set; }
    }
}
