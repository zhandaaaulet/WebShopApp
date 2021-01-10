using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Domain.Model.Shared
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type entityType)
        {
            EntityType = entityType;
        }

        public EntityNotFoundException(Type entityType, string message) : base(message)
        {
            EntityType = entityType;
        }

        public EntityNotFoundException(Type entityType, string message, Exception innerException) : base(message, innerException)
        {
            EntityType = entityType;
        }

        public Type EntityType { get; }
    }
}
