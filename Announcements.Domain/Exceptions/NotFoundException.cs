namespace Announcements.Domain.Exceptions
{
    /// <summary>
    /// Объект не найден
    /// </summary>
    public abstract class NotFoundException : DomainException
    {
        protected NotFoundException(string message) : base(message)
        {

        }
    }
}
