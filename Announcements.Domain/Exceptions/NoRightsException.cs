namespace Announcements.Domain.Exceptions
{
    /// <summary>
    /// Нет прав
    /// </summary>
    public abstract class NoRightsException : DomainException
    {
        protected NoRightsException(string message) : base(message)
        {

        }
    }
}
