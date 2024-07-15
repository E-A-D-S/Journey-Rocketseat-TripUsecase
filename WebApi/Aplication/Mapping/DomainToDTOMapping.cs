using AutoMapper;
using WebApi.Domain.DTOs;
using WebApi.Domain.Model.EmployeeAggregate;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Application.Mapping
{
    /// <summary>
    /// Mapeamento de classes de domínio para DTOs.
    /// </summary>
    public class DomainToDTOMapping : Profile
    {
        /// <summary>
        /// Inicializa um novo instância de <see cref="DomainToDTOMapping"/>.
        /// </summary>
        public DomainToDTOMapping()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.NameEmployee, m => m.MapFrom(orig => orig.name));
        }
    }
}
