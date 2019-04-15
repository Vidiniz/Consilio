using ConsilioServices.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ConsilioServices.Application.Validations
{
    public class GenerationCredentials
    {
        public string GetCrendentials(SystemUser systemUser, char[] configuration)
        {           
            var token = GetGeneratedCredentials(systemUser, configuration);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string ValidateCredentials(string token, char[] configuration)
        {
            ClaimsPrincipal claimsPrincipal;

            var validationParameters = new TokenValidationParameters
            {
                ValidIssuer              = "consilio.system",
                ValidAudience            = "consilio.system",
                IssuerSigningKey         = GetSymmetricSecurityKey(configuration),
                ValidateIssuerSigningKey = true,
                ValidateAudience         = true
            };

            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException("Token inválido ou nulo!");
            
            claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out SecurityToken valitedToken);

            return claimsPrincipal.Claims.Where(c => c.Type.Equals(ClaimTypes.Email)).FirstOrDefault().Value;            
        }

        private Claim[] GetClaims(SystemUser systemUser)
        {
            return new[]
            {
                new Claim(ClaimTypes.Name, $"{systemUser.Name} {systemUser.LastName}"),
                new Claim(ClaimTypes.Email, systemUser.Email),
                new Claim(ClaimTypes.Role, systemUser.SystemProfile.Name),
                new Claim("UserId", systemUser.Id.ToString())
            };
        }
        
        private SigningCredentials GetSigningCredentials(char[] configuration)
        {
            return new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration)),
                SecurityAlgorithms.HmacSha256);
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey(char[] configuration)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration));
        }

        private JwtSecurityToken GetGeneratedCredentials(SystemUser systemUser, char[] configuration)
        {
            if (systemUser != null)
            {
                return new JwtSecurityToken(
                issuer            : "consilio.system",
                audience          : "consilio.system",
                claims            : GetClaims(systemUser),
                expires           : DateTime.Now.AddHours(2),
                signingCredentials: GetSigningCredentials(configuration));
            }

            return new JwtSecurityToken(
                issuer            : "consilio.system",
                audience          : "consilio.system",                
                expires           : DateTime.Now.AddHours(2),
                signingCredentials: GetSigningCredentials(configuration));            
        }

    }    
}
