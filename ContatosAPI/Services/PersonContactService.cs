using ContatosAPI.Models;
using ContatosAPI.Repositories;

namespace ContatosAPI.Services
{
    public class PersonContactService
    {
        private readonly IContactRepository<Person> _repository;

        public PersonContactService(IContactRepository<Person> repository)
        {
            _repository = repository;
        }

        public List<Person> GetAll()
        {
            return _repository.GetAll(x => !x.IsDeleted).ToList();
        }

        public Person? GetById(Guid id)
        {
            return _repository.GetByParams(x => x.Id == id, p => p.PhoneContacts, p => p.EmailContacts);
        }

        public Person Add(Person newPerson)
        {
            var person = new Person(newPerson.Name, newPerson.LastName, newPerson.Cpf);

            _repository.Add(person);
            _repository.Save();
            return person;
        }

        public void Update(Person person)
        {
            var _person = _repository.GetById(person.Id);

            if (_person == null)
            {
                throw new Exception("Pessoa não encontrado");
            }

            _person.Update(person.Name, person.LastName, person.Cpf);

            _repository.Update(_person);
            _repository.Save();
        }

        public void Delete(Guid id)
        {
            var person = _repository.GetById(id);

            if (person == null)
            {
                throw new Exception("Não encontrado");
            }

            _repository.Delete(person);
            _repository.Save();
        }
    }
}
