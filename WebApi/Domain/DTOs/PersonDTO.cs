namespace WebApi.Domain.DTOs
{
    /// <summary>
    /// DTO (Data Transfer Object) para representar informações simplificadas de uma pessoa.
    /// </summary>
    public class PersonDTO
    {
        /// <summary>
        /// ID da pessoa.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome da pessoa.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Idade da pessoa.
        /// </summary>
        public int Age { get; set; }
        // Outras propriedades conforme necessário
    }
}