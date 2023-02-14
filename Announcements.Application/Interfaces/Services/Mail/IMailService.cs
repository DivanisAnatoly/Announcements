using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Interfaces.Services.Mail
{
    public interface IMailService
    {
        Task Send(string recipient, string subject, string message, CancellationToken cancellationToken);
    }
}
