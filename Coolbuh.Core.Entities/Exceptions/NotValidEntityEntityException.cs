using System;
using System.Runtime.Serialization;

namespace Coolbuh.Core.Entities.Exceptions
{
    /// <summary>
    /// Ошибка валидации доменной сущности
    /// </summary>
    [Serializable]
    public class NotValidEntityEntityException : Exception
    {
        public NotValidEntityEntityException(string message) : base(message)
        { }

        protected NotValidEntityEntityException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        { }
    }
}
