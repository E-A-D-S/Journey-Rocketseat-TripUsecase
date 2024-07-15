using Microsoft.IdentityModel.Tokens;
using WebApi;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Domain.Model.EmployeeAggregate;

namespace WebApi.Application.Services
{
    /// <summary>
    /// Serviço para geração de tokens JWT.
    /// </summary>
    public class TokenService
    {
        /// <summary>
        /// Gera um token JWT para o funcionário especificado.
        /// </summary>
        /// <param name="employee">O funcionário para o qual gerar o token.</param>
        /// <returns>O token JWT gerado.</returns>
        public static object GenerateToken(Employee employee)
        {
            var key = Encoding.ASCII.GetBytes(Key.Secret);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("employeeId", employee.id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new
            {
                token = tokenString
            };
        }
    }
}
