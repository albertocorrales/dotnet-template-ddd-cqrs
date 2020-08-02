using System;
using System.Diagnostics.CodeAnalysis;

namespace MicroserviceTemplate.Domain.Events
{
    [ExcludeFromCodeCoverage]
    public class ItemCreated
    {
        public Guid Id { get; }
        public string Tenant { get; }
        public string Name { get; private set; }
        public ItemCreated(Guid id, string name, string tenant)
        {
            Id = id;
            Tenant = tenant;
            Name = name;
        }
    }
}
