using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ViewModel;
using WebApi.Domain.DTOs;
using WebApi.Domain.Model.EmployeeAggregate;


namespace WebApi.Controllers.v1
{
    /// <summary>
    /// Controlador para lidar com operações relacionadas a funcionários.
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/employee")]
    [ApiVersion("1.0")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="EmployeeController"/>.
        /// </summary>
        /// <param name="employeeRepository">O repositório de funcionários.</param>
        /// <param name="logger">O logger.</param>
        /// <param name="mapper">O mapeador.</param>
        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Adiciona um novo funcionário.
        /// </summary>
        /// <param name="employeeView">Os dados do funcionário a serem adicionados.</param>
        /// <returns>O resultado da operação.</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {

            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeView.Photo.CopyTo(fileStream);

            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);

            _employeeRepository.Add(employee);

            return Ok();
        }

        /// <summary>
        /// Faz o download da foto de um funcionário.
        /// </summary>
        /// <param name="id">O ID do funcionário.</param>
        /// <returns>O arquivo de imagem do funcionário.</returns>
        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            return File(dataBytes, "image/png");
        }

        /// <summary>
        /// Obtém uma página de funcionários.
        /// </summary>
        /// <param name="pageNumber">O número da página.</param>
        /// <param name="pageQuantity">A quantidade de funcionários por página.</param>
        /// <returns>A página de funcionários.</returns>
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            _logger.Log(LogLevel.Error, "Teve um Erro");

            var employess = _employeeRepository.Get(pageNumber, pageQuantity);

            _logger.LogInformation("Teste");

            return Ok(employess);
        }
        /// <summary>
        /// Busca um funcionário pelo ID.
        /// </summary>
        /// <param name="id">O ID do funcionário.</param>
        /// <returns>O funcionário encontrado.</returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Search(int id)
        {
            var employess = _employeeRepository.Get(id);

            var employeesDTOS = _mapper.Map<EmployeeDTO>(employess);

            return Ok(employeesDTOS);
        }
    }
}