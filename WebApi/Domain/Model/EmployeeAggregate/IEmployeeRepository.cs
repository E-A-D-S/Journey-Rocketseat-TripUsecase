using System.Collections.Generic;
using WebApi.Domain.DTOs;

namespace WebApi.Domain.Model.EmployeeAggregate
{
    /// <summary>
    /// Interface para o repositório de funcionários.
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Adiciona um funcionário.
        /// </summary>
        /// <param name="employee">Funcionário a ser adicionado.</param>
        void Add(Employee employee);

        /// <summary>
        /// Obtém uma lista paginada de funcionários.
        /// </summary>
        /// <param name="pageNumber">Número da página.</param>
        /// <param name="pageQuantity">Quantidade de funcionários por página.</param>
        /// <returns>Lista paginada de funcionários.</returns>
        List<EmployeeDTO> Get(int pageNumber, int pageQuantity);

        /// <summary>
        /// Obtém um funcionário pelo ID.
        /// </summary>
        /// <param name="id">ID do funcionário a ser obtido.</param>
        /// <returns>O funcionário encontrado, ou null se não encontrado.</returns>
        Employee? Get(int id);
    }
}
