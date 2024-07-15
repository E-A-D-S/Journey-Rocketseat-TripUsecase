using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ViewModel;
using WebApi.Domain.Model.PersonAggregate;
using WebApi.Domain.Repositories;
using System.Threading.Tasks;

namespace WebApi.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/person")]
    [ApiVersion("2.0")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PersonViewModel personView)
        {
            var person = new Person
            {
                Name = personView.Name,
                Age = personView.Age
            };

            await _personRepository.AddAsync(person);

            return Ok();
        }

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
            };

            return Ok(personView);
        }

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

            await _personRepository.UpdateAsync(id, existingPerson);

            return Ok();
        }

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
