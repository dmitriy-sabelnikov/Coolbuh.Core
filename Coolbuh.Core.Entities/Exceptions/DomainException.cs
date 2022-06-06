using System;

namespace Coolbuh.Core.Entities.Exceptions
{
    /// <summary>
    /// Ошибка доменного слоя
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        { }
    }
}
