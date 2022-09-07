using Comum.Aplicacao.Services.Interfaces;
using Comum.Dominio.Entidades;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Comum.Aplicacao.Services
{
    public class TokenService : ITokenService
    {
        public string GetToken(Usuario usuario, string jwtKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtKey);
            var claims = GetClaims(usuario);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Obter Array de Claims para configuração do jwt token
        /// </summary>
        private Claim[] GetClaims(Usuario user)
        {
            if(!user.Permissao.Any())
                throw new ArgumentNullException(nameof(user.Permissao));

            List<Claim> ret = new();

            ret.Add(new Claim(
                    type: ClaimTypes.Name,
                    value: user.Nome));

            if (user.Permissao.Count > 1)
            {
                foreach (var permissao in user.Permissao)
                    ret.Add(new Claim(
                            type: ClaimTypes.Role, // Tipo de claim (Permissão)
                            value: permissao.ToString())); // Valor
            }
            else
            {
                ret.Add(new Claim(
                    type: ClaimTypes.Role,
                    value: user.Permissao.First().ToString()));
            }

            return ret.ToArray();
        }
    }
}
