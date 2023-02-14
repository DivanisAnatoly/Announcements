using Announcements.Application.Interfaces.Services.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Infrastructure.Identity
{

    /// <inheritdoc cref="ITokenGenerator"/>
    ///<summary>Генератор JWT токенов</summary>
    public class JwtTokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Конструктор
        /// </summary>
        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <inheritdoc/>
        public async Task<string> ReceiveTokenFromClaims(IReadOnlyCollection<Claim> userClaims, CancellationToken cancellationToken)
        {
            var token = new JwtSecurityToken
            (
                claims: userClaims,
                expires: DateTime.UtcNow.AddDays(20),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])),
                    SecurityAlgorithms.HmacSha256
                    )
            );

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

    }
}
