using System.Globalization;

namespace ContatosAPI.Models
{
    public class Person
    {
        public Person(string name, string lastName, string cpf)
        {
            TextInfo textCultura = new CultureInfo("pt-BR", false).TextInfo;

            Id = Guid.NewGuid();
            Name = textCultura.ToTitleCase(name.ToLower()).Trim();
            LastName = textCultura.ToTitleCase(lastName.ToLower()).Trim();
            Cpf = cpf;
            PhoneContacts = new List<PhoneContact>();
            EmailContacts = new List<EmailContact>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }

        public List<PhoneContact> PhoneContacts { get; set; }
        public List<EmailContact> EmailContacts { get; set; }

        public void Update(string name, string lastName, string cpf)
        {
            TextInfo textCultura = new CultureInfo("pt-BR", false).TextInfo;

            Name = textCultura.ToTitleCase(name.ToLower()).Trim();
            LastName = textCultura.ToTitleCase(lastName.ToLower()).Trim();
            Cpf = cpf;
        }
    }
}
