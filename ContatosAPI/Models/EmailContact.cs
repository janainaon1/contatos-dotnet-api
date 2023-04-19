namespace ContatosAPI.Models
{
    public class EmailContact
    {
        public EmailContact(string emailAddress, Guid personId)
        {
            Id = Guid.NewGuid();
            EmailAddress = emailAddress;
            PersonId = personId;
        }

        public Guid Id { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public Guid PersonId { get; set; }

        public void Update(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}
