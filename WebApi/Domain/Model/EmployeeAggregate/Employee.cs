using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Model.EmployeeAggregate
{
    /// <summary>
    /// Representa um funcionário na aplicação.
    /// </summary>
    [Table("employee")]
    public class Employee
    {
        /// <summary>
        /// ID do funcionário.
        /// </summary>
        [Key]
        public int id { get; private set; }
        /// <summary>
        /// Nome do funcionário.
        /// </summary>
        public string name { get; private set; }
        /// <summary>
        /// Idade do funcionário.
        /// </summary>
        public int age { get; private set; }
        /// <summary>
        /// Caminho para a foto do funcionário.
        /// </summary>
        public string? photo { get; private set; }
        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public Employee() { }
        /// <summary>
        /// Construtor que inicializa um funcionário com nome, idade e foto.
        /// </summary>
        /// <param name="name">Nome do funcionário.</param>
        /// <param name="age">Idade do funcionário.</param>
        /// <param name="photo">Caminho para a foto do funcionário.</param>
        public Employee(string name, int age, string photo)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.age = age;
            this.photo = photo;
        }
    }
}

