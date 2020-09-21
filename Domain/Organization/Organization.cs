using System;
using Region.Accounting.Domain.Common;

namespace Region.Accounting.Domain.Organization
{
    public class Organization : Aggregate
    {
        //public OrganizationId Id { get; }
        public string Name { get; }

        public Organization(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}