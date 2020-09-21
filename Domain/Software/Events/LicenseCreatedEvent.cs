using System;
using Region.Accounting.Domain.Common;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Software.License;

namespace Region.Accounting.Domain.Software.Events
{
    public class LicenseCreatedEvent : DomainEvent
    {
        public LicenseKey Key { get; }
        public DateTime DateStart { get; }
        public DateTime DateEnd { get; }
        public OrganizationId OrganizationId { get; }
        public int Activations { get; }
        public int Price { get; }
        public string Description { get; }

        public LicenseCreatedEvent(LicenseKey key, DateTime dateStart, DateTime dateEnd, OrganizationId organizationId, int activations, int price, string description)
        {
            Key = key;
            DateStart = dateStart;
            DateEnd = dateEnd;
            OrganizationId = organizationId;
            Activations = activations;
            Price = price;
            Description = description;
        }
    }
}