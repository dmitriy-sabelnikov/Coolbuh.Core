using System;
using System.Runtime.Serialization;

namespace Coolbuh.Core.UseCases.Exceptions
{
    /// <summary>
    /// Ошибка слоя бизнес правил приложения
    /// </summary>
    [Serializable]
    public class UseCaseException : Exception
    {
        public UseCaseException(string message) : base(message)
        { }

        protected UseCaseException(SerializationInfo serializationInfo, StreamingContext streamingContext) 
            : base(serializationInfo, streamingContext) 
        { }
    }
}
