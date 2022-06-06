using System;

namespace Coolbuh.Core.UseCases.Exceptions
{
    /// <summary>
    /// Ошибка отсутствия объекта  
    /// </summary>
    public class NotFoundEntityUseCaseException : Exception
    {
        public NotFoundEntityUseCaseException(string message) : base(message)
        {
        }
    }
}
