namespace WebApi.Domain.DTOs
{
    /// <summary>
    /// DTO (Data Transfer Object) para representar informações simplificadas de um funcionário.
    /// </summary>
    public class EmployeeDTO
    {
        /// <summary>
        /// ID do funcionário.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do funcionário.
        /// </summary>
        public string NameEmployee { get; set; }
        /// <summary>
        /// Foto do funcionário (opcional).
        /// </summary>
        public string? Photo { get; set; }
    }
}