using System;

namespace Announcements.Domain.Exceptions
{
    /// <summary>
    /// Ошибка в слое Domain
    /// </summary>
    public abstract class DomainException : ApplicationException
    {
        protected DomainException(string message) : base(message) { }
    }
}
