using System;
using System.Diagnostics.CodeAnalysis;

namespace MicroserviceTemplate.Domain.Events
{
    [ExcludeFromCodeCoverage]
    public class ItemUpdated
    {
        public Guid Id { get; }
        public string Tenant { get; }
        public string Name { get; private set; }
        public ItemUpdated(Guid id, string name, string tenant)
        {
            Id = id;
            Name = name;
            Tenant = tenant;
        }
    }
}
