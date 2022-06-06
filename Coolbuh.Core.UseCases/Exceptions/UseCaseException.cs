using System;

namespace Coolbuh.Core.UseCases.Exceptions
{
    /// <summary>
    /// Ошибка слоя бизнес правил приложения
    /// </summary>
    public class UseCaseException : Exception
    {
        public UseCaseException(string message) : base(message)
        { }
    }
}
