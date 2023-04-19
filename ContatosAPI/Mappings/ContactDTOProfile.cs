using AutoMapper;
using ContatosAPI.DTOs;
using ContatosAPI.Models;

namespace ContatosAPI.Mappings
{
    public class ContactDTOProfile : Profile
    {
        public ContactDTOProfile()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Person, AddPersonDTO>().ReverseMap();
            CreateMap<Person, PersonDetailsDTO>().ReverseMap();

            CreateMap<PhoneContact, AddPhoneContactDTO>().ReverseMap();
            CreateMap<PhoneContact, PhoneContactDTO>().ReverseMap();

            CreateMap<EmailContact, EmailContactDTO>().ReverseMap();
            CreateMap<EmailContact, AddEmailContactDTO>().ReverseMap();

        }
    }
}
