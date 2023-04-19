namespace ContatosAPI.Models
{
    public class PhoneContact
    {
        public PhoneContact(string phoneNumber, bool isWhatsapp, Guid personId)
        {
            Id = Guid.NewGuid();
            PhoneNumber = phoneNumber;
            IsWhatsapp = isWhatsapp;
            PersonId = personId;
        }

        public Guid Id { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsWhatsapp { get; set; }
        public Guid PersonId { get; set; }

        public void Update(string phoneNumber, bool isWhatsapp)
        {
            PhoneNumber = phoneNumber;
            IsWhatsapp = isWhatsapp;
        }
    }
}
