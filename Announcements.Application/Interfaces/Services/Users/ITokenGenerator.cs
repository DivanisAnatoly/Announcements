using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Interfaces.Services.Users
{
    public interface ITokenGenerator
    {
        /// <summary>
        /// Получить токен из Claim-ов
        /// </summary>
        Task<string> ReceiveTokenFromClaims(IReadOnlyCollection<Claim> claims, CancellationToken cancellationToken);

    }

}
