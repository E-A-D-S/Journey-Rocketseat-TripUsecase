using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ViewModel;
using WebApi.Domain.Model.PersonAggregate;
using WebApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    /// <summary>
    /// Controlador para lidar com operações relacionadas a pessoas.
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/person")]
    [ApiVersion("1.0")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        /// <summary>
        /// Inicializa uma nova instância de <see cref="PersonController"/>.
        /// </summary>
        /// <param name="personRepository">O repositório de pessoas.</param>
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        /// <summary>
        /// Adiciona uma nova pessoa.
        /// </summary>
        /// <param name="personView">Os dados da pessoa a serem adicionados.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PersonViewModel personView)
        {
            var person = new Person
            {
                Name = personView.Name,
                Age = personView.Age
                // Se necessário, adicione outras propriedades da Person
            };

            await _personRepository.AddAsync(person);

            return Ok();
        }
        /// <summary>
        /// Obtém uma pessoa pelo ID.
        /// </summary>
        /// <param name="id">O ID da pessoa.</param>
        /// <returns>A pessoa encontrada.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            var personView = new PersonViewModel
            {
                Name = person.Name,
                Age = person.Age
                // Se necessário, adicione outras propriedades da Person
            };

            return Ok(personView);
        }
        /// <summary>
        /// Atualiza uma pessoa existente.
        /// </summary>
        /// <param name="id">O ID da pessoa a ser atualizada.</param>
        /// <param name="personView">Os novos dados da pessoa.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonViewModel personView)
        {
            var existingPerson = await _personRepository.GetByIdAsync(id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            existingPerson.Name = personView.Name;
            existingPerson.Age = personView.Age;
            // Atualize outras propriedades da Person conforme necessário

            await _personRepository.UpdateAsync(id, existingPerson);

            return Ok();
        }
        /// <summary>
        /// Exclui uma pessoa pelo ID.
        /// </summary>
        /// <param name="id">O ID da pessoa a ser excluída.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingPerson = await _personRepository.GetByIdAsync(id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            await _personRepository.DeleteAsync(id);

            return Ok();
        }
    }
}
