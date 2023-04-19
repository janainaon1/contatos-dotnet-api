using ContatosAPI.Models;
using ContatosAPI.Repositories;

namespace ContatosAPI.Services
{
    public class PhoneContactService
    {
        private readonly IContactRepository<PhoneContact> _contactRepository;
        private readonly IContactRepository<Person> _personRepository;

        public PhoneContactService(IContactRepository<PhoneContact> contactRepository, IContactRepository<Person> personRepository)
        {
            _contactRepository = contactRepository;
            _personRepository = personRepository;
        }

        public PhoneContact? GetAllById(Guid id)
        {
            var contact = _contactRepository.GetById(id);
            return contact;
        }

        public List<PhoneContact> GetAllByPersonId(Guid personId)
        {
            var contacts = _contactRepository.GetAll(x => x.PersonId == personId);
            return contacts;
        }

        public PhoneContact Add(PhoneContact newContact)
        {
            var person = _personRepository.GetById(newContact.PersonId);
            if (person == null)
            {
                throw new Exception("Pessoa não encontrada.");
            }

            var contact = new PhoneContact(newContact.PhoneNumber, newContact.IsWhatsapp, newContact.PersonId);

            _contactRepository.Add(contact);
            _contactRepository.Save();

            return contact;
        }

        public void Update(PhoneContact inputContact)
        {
            var _contact = _contactRepository.GetById(inputContact.Id);

            if (_contact == null)
            {
                throw new Exception("Contato não encontrado");
            }

            _contact.Update(inputContact.PhoneNumber, inputContact.IsWhatsapp);

            _contactRepository.Update(_contact);
            _contactRepository.Save();
        }

        public void Delete(Guid id)
        {
            var _contact = _contactRepository.GetById(id);

            if (_contact == null)
            {
                throw new Exception("Contato não encontrado");
            }

            _contactRepository.Delete(_contact);
            _contactRepository.Save();
        }
    }
}
