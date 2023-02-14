using Announcements.Domain.Exceptions;

namespace Announcements.Application.Interfaces.Services.Files.Contracts.Exceptions
{
    /// <summary>
    /// Файл не найден
    /// </summary>
    class FileNotFoundException : NotFoundException
    {
        public FileNotFoundException(string message) : base(message) { }
    }

}
