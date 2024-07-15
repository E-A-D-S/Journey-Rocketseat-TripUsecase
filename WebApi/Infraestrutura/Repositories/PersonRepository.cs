using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Model.PersonAggregate;
using WebApi.Domain.Repositories;

namespace WebApi.Infraestrutura.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ConnectionContext _context;

        public PersonRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<int> AddAsync(Person person)
        {
            _context.Persons.Add(person);
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Person person)
        {
            var existingPerson = await _context.Persons.FindAsync(id);
            if (existingPerson != null)
            {
                existingPerson.Name = person.Name;
                existingPerson.Age = person.Age;
                // Atualize outras propriedades conforme necessário
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}
