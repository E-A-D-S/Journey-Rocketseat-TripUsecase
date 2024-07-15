using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Model.CompanyAggregate
{
    /// <summary>
    /// Representa uma empresa.
    /// </summary>
    [Table("company")]
    public class Company
    {
        /// <summary>
        /// Obtém ou define o ID da empresa.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Obtém ou define o nome da empresa.
        /// </summary>
        public string Nome { get; set; }
    }
}
