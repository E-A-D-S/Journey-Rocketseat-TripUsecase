namespace WebApi.Domain.Model.PersonAggregate
{
    /// <summary>
    /// Representa uma pessoa.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Obtém ou define o ID da pessoa.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtém ou define o nome da pessoa.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtém ou define a idade da pessoa.
        /// </summary>
        public int Age { get; set; }

        // Outras propriedades conforme necessário
    }
}
