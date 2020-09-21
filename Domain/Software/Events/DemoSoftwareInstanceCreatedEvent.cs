using System;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Server;
using Region.Accounting.Domain.Software.SoftwareInstance;

namespace Region.Accounting.Domain.Software.Events
{
    public class DemoSoftwareInstanceCreatedEvent : SoftwareInstanceCreatedEvent
    {
        public DateTime Expiration { get; }

        public DemoSoftwareInstanceCreatedEvent(SoftwareInstanceId id, DateTime installDate, ServerId serverId,
            OrganizationId organizationId, DateTime expiration) : base(id, installDate, serverId, organizationId)
        {
            Expiration = expiration;
        }
    }
}