using System;
using System.Diagnostics.CodeAnalysis;

namespace MicroserviceTemplate.Domain.Events
{
    [ExcludeFromCodeCoverage]
    public class ItemDeleted
    {
        public Guid Id { get; }
        public string Tenant { get; }
        public ItemDeleted(Guid id, string tenant)
        {
            Id = id;
            Tenant = tenant;
        }
    }
}
