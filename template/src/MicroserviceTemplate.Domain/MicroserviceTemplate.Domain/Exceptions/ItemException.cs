using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace MicroserviceTemplate.Domain.Exceptions
{
    [Serializable, ExcludeFromCodeCoverage]
    public class ItemException : Exception
    {
        public ItemException(string message)
            : base(message)
        { }

        protected ItemException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}