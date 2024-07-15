using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Model.PersonAggregate;

namespace WebApi.Domain.Repositories
{
    /// <summary>
    /// Interface para o repositório de pessoas.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Obtém uma pessoa pelo ID de forma assíncrona.
        /// </summary>
        /// <param name="id">ID da pessoa a ser obtida.</param>
        /// <returns>A pessoa encontrada.</returns>
        Task<Person> GetByIdAsync(int id);

        /// <summary>
        /// Obtém todas as pessoas de forma assíncrona.
        /// </summary>
        /// <returns>Lista de todas as pessoas.</returns>
        Task<List<Person>> GetAllAsync();

        /// <summary>
        /// Adiciona uma pessoa de forma assíncrona.
        /// </summary>
        /// <param name="person">Pessoa a ser adicionada.</param>
        /// <returns>O ID da pessoa adicionada.</returns>
        Task<int> AddAsync(Person person);

        /// <summary>
        /// Atualiza uma pessoa de forma assíncrona.
        /// </summary>
        /// <param name="id">ID da pessoa a ser atualizada.</param>
        /// <param name="person">Pessoa com os novos dados.</param>
        Task UpdateAsync(int id, Person person);

        /// <summary>
        /// Deleta uma pessoa de forma assíncrona.
        /// </summary>
        /// <param name="id">ID da pessoa a ser deletada.</param>
        Task DeleteAsync(int id);
    }
}
