using System;
using System.Runtime.Serialization;

namespace Coolbuh.Core.Entities.Exceptions
{
    /// <summary>
    /// Ошибка доменного слоя
    /// </summary>
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        { }

        protected DomainException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            :base(serializationInfo, streamingContext) 
        { }
    }
}
