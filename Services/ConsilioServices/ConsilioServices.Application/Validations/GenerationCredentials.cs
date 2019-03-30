using ConsilioServices.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConsilioServices.Application.Validations
{
    public class GenerationCredentials
    {
        public string GetCrendentials(SystemUser systemUser, char[] configuration)
        {
            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration)), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "consilio.system",
                audience: "consilio.system",
                claims: GetClaims(systemUser),
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Claim[] GetClaims(SystemUser systemUser)
        {
            return new[]
            {
                new Claim(ClaimTypes.Name, $"{systemUser.Name} {systemUser.LastName}"),
                new Claim(ClaimTypes.Email, systemUser.Email)
            };
        }
        
    }    
}
