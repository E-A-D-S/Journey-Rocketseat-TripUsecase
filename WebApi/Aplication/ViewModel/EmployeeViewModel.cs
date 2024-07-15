namespace WebApi.Application.ViewModel
{
    /// <summary>
    /// ViewModel para representar os dados de um funcionário.
    /// </summary>
    public class EmployeeViewModel
    {
        /// <summary>
        /// Obtém ou define o nome do funcionário.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtém ou define a idade do funcionário.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Obtém ou define a foto do funcionário.
        /// </summary>
        public IFormFile Photo { get; set; }
    }
}
