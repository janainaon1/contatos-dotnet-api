using Microsoft.AspNetCore.Mvc;
using ContatosAPI.Services;
using ContatosAPI.DTOs;
using AutoMapper;
using ContatosAPI.Models;

namespace ContatosAPI.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContactService _personContactService;
        private readonly IMapper _mapper;

        public PersonController(PersonContactService personContactService, IMapper mapper) 
        {
            _personContactService = personContactService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obter todas as Pessoas
        /// </summary>
        /// <returns>Coleção de Pessoas</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var personList = _personContactService.GetAll();

            var personListDTO = _mapper.Map<List<PersonDTO>>(personList);

            return Ok(personListDTO);
        }

        /// <summary>
        /// Obter os dados de uma Pessoa
        /// </summary>
        /// <param name="id">Identificador da Pessoa</param>
        /// <returns>Dados da Pessoa</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var person = _personContactService.GetById(id);

            if (person == null)
            {
                return NotFound();
            }

            var personDTO = _mapper.Map<PersonDetailsDTO>(person);

            return Ok(personDTO);
        }

        /// <summary>
        /// Cadastrar uma Pessoa
        /// </summary>
        /// <remarks>
        /// {"name":"Maria","lastName":"Silva","cpf":"99999999999"}
        /// </remarks>
        /// <param name="personDTO">Dados da Pessoa</param>
        /// <returns>Pessoa recém-criada</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(AddPersonDTO personDTO)
        {
            var person = _mapper.Map<Person>(personDTO);
            var _person = _personContactService.Add(person);

            var _personDTO = _mapper.Map<PersonDTO>(_person);

            return CreatedAtAction(nameof(GetById), new { id = _person.Id }, _personDTO);
        }

        /// <summary>
        /// Atualizar uma Pessoa
        /// </summary>
        /// <remarks>
        /// {"id":"3fa85f64-5717-4562-b3fc-2c963f66afa6","name":"Maria 2","lastName":"Silva 2","cpf":"22222222222"}
        /// </remarks>
        /// <param name="personDTO">Dados da Pessoa</param>
        /// <returns>Nada</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update(PersonDTO personDTO)
        {
            var person = _mapper.Map<Person>(personDTO);
            _personContactService.Update(person);

            return NoContent();
        }

        /// <summary>
        /// Deletar uma Pessoa
        /// </summary>
        /// <param name="id">Identificador da Pessoa</param>
        /// <returns>Nada</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(Guid id)
        {
            _personContactService.Delete(id);

            return NoContent();
        }
    }
}