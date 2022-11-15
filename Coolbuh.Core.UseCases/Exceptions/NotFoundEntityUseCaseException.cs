using System;
using System.Runtime.Serialization;

namespace Coolbuh.Core.UseCases.Exceptions
{
    /// <summary>
    /// Ошибка отсутствия объекта  
    /// </summary>
    [Serializable]
    public class NotFoundEntityUseCaseException : Exception
    {
        public NotFoundEntityUseCaseException(string message) : base(message)
        { }

        protected NotFoundEntityUseCaseException(SerializationInfo serializationInfo, StreamingContext streamingContext) 
            : base(serializationInfo, streamingContext) 
        { }
    }
}
