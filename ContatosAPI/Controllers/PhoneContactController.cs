using AutoMapper;
using ContatosAPI.DTOs;
using ContatosAPI.Models;
using ContatosAPI.Repositories;
using ContatosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContatosAPI.Controllers
{
    [Route("api/phone-contact")]
    [ApiController]
    public class PhoneContactController : ControllerBase
    {
        private readonly PhoneContactService _phoneContactService;
        private readonly IMapper _mapper;

        public PhoneContactController(PhoneContactService phoneContactService, IMapper mapper)
        {
            _phoneContactService = phoneContactService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obter os Telefones de contatos de uma Pessoa específica
        /// </summary>
        /// <returns>Coleção de Telefones de contato</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet("{personId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetByPersonId(Guid personId)
        {
            var phoneContacts = _phoneContactService.GetAllByPersonId(personId);

            var phoneContactsDTO = _mapper.Map<List<PhoneContactDTO>>(phoneContacts);

            return Ok(phoneContactsDTO);
        }

        /// <summary>
        /// Cadastrar um Telefone de contato
        /// </summary>
        /// <remarks>
        /// {"phoneNumber":"19999999999","isWhatsapp":true,"personId":"3fa85f64-5717-4562-b3fc-2c963f66afa6"}
        /// </remarks>
        /// <param name="phoneContactDTO">Dados do Telefone de contato</param>
        /// <returns>Contato recém-criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(AddPhoneContactDTO phoneContactDTO)
        {
            var phoneContact = _mapper.Map<PhoneContact>(phoneContactDTO);
            var phone = _phoneContactService.Add(phoneContact);

            var _phoneDTO = _mapper.Map<PhoneContactDTO>(phone);

            return CreatedAtAction(nameof(GetByPersonId), new { personId = phone.PersonId }, _phoneDTO);
        }

        /// <summary>
        /// Atualizar Telefone de contato
        /// </summary>
        /// <remarks>
        /// {"id":"3fa85f64-5717-4562-b3fc-2c963f66afa6","phoneNumber":"19999999999","isWhatsapp":true,"personId":"3fa85f64-5717-4562-b3fc-2c963f66afa6"}
        /// </remarks>
        /// <param name="phoneContactDTO">Dados do Telefone de contato</param>
        /// <returns>Nada</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update(PhoneContactDTO phoneContactDTO)
        {
            var phoneContact = _mapper.Map<PhoneContact>(phoneContactDTO);
            _phoneContactService.Update(phoneContact);

            return NoContent();
        }

        /// <summary>
        /// Deletar um Telefone de contato
        /// </summary>
        /// <param name="id">Identificador do Telefone de contato</param>
        /// <returns>Nada</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(Guid id)
        {
            _phoneContactService.Delete(id);

            return NoContent();
        }
    }
}
