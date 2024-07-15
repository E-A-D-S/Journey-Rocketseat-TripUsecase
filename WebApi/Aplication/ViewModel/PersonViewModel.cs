using Microsoft.AspNetCore.Http;

namespace WebApi.Application.ViewModel
{
    /// <summary>
    /// ViewModel para representar os dados de uma pessoa.
    /// </summary>
    public class PersonViewModel
    {
        /// <summary>
        /// Obtém ou define o nome da pessoa.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtém ou define a idade da pessoa.
        /// </summary>
        public int Age { get; set; }
        public int Id { get; internal set; }

        // Outras propriedades conforme necessário
    }
}
