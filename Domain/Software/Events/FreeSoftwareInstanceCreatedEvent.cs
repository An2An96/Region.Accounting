using System;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Server;
using Region.Accounting.Domain.Software.SoftwareInstance;

namespace Region.Accounting.Domain.Software.Events
{
    public class FreeSoftwareInstanceCreatedEvent : SoftwareInstanceCreatedEvent
    {
        public FreeSoftwareInstanceCreatedEvent(SoftwareInstanceId id, DateTime installDate, ServerId serverId,
            OrganizationId organizationId) : base(id, installDate, serverId, organizationId)
        {
        }
    }
}