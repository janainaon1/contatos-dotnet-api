using AutoMapper;
using ContatosAPI.DTOs;
using ContatosAPI.Models;
using ContatosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContatosAPI.Controllers
{
    [Route("api/email-contact")]
    [ApiController]
    public class EmailContactController : ControllerBase
    {
        private readonly EmailContactService _emailContactService;
        private readonly IMapper _mapper;

        public EmailContactController(EmailContactService emailContactService, IMapper mapper)
        {
            _emailContactService = emailContactService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obter os E-mail de contatos de uma Pessoa específica
        /// </summary>
        /// <returns>Coleção de E-mail de contato</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet("{personId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetByPersonId(Guid personId)
        {
            var emailContacts = _emailContactService.GetAllByPersonId(personId);

            var emailContactsDTO = _mapper.Map<List<EmailContact>>(emailContacts);

            return Ok(emailContactsDTO);
        }

        /// <summary>
        /// Cadastrar um E-mail de contato
        /// </summary>
        /// <remarks>
        /// {"emailAddress":"teste@teste.com","personId":"3fa85f64-5717-4562-b3fc-2c963f66afa6"}
        /// </remarks>
        /// <param name="emailContactDTO">Dados do E-mail de contato</param>
        /// <returns>Contato recém-criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(AddEmailContactDTO emailContactDTO)
        {
            var emailContact = _mapper.Map<EmailContact>(emailContactDTO);

            var _email = _emailContactService.Add(emailContact);

            var _emailDTO = _mapper.Map<EmailContactDTO>(_email);

            return CreatedAtAction(nameof(GetByPersonId), new { personId = _email.PersonId }, _emailDTO);
        }

        /// <summary>
        /// Atualizar E-mail de contato
        /// </summary>
        /// <remarks>
        /// {"id":"3fa85f64-5717-4562-b3fc-2c963f66afa6","emailAddress":"teste@teste.com","personId":"3fa85f64-5717-4562-b3fc-2c963f66afa6"}
        /// </remarks>
        /// <param name="emailContactDTO">Dados do E-mail de contato</param>
        /// <returns>Nada</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update(EmailContactDTO emailContactDTO)
        {
            var emailContact = _mapper.Map<EmailContact>(emailContactDTO);

            _emailContactService.Update(emailContact);

            return NoContent();
        }

        /// <summary>
        /// Deletar um E-mail de contato
        /// </summary>
        /// <param name="id">Identificador do E-mail de contato</param>
        /// <returns>Nada</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(Guid id)
        {
            _emailContactService.Delete(id);

            return NoContent();
        }
    }
}
