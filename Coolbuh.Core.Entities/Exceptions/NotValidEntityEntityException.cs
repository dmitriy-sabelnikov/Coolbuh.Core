using System;

namespace Coolbuh.Core.Entities.Exceptions
{
    /// <summary>
    /// Ошибка валидации доменной сущности
    /// </summary>
    public class NotValidEntityEntityException : Exception
    {
        public NotValidEntityEntityException(string message) : base(message)
        {
        }
    }
}
