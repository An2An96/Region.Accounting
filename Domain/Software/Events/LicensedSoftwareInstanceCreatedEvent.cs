using System;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Server;
using Region.Accounting.Domain.Software.License;
using Region.Accounting.Domain.Software.SoftwareInstance;

namespace Region.Accounting.Domain.Software.Events
{
    public class LicensedSoftwareInstanceCreatedEvent : SoftwareInstanceCreatedEvent
    {
        public LicenseKey Key { get; }

        public LicensedSoftwareInstanceCreatedEvent(SoftwareInstanceId id, DateTime installDate, ServerId serverId,
            OrganizationId organizationId, LicenseKey key) : base(id, installDate, serverId, organizationId)
        {
            Key = key;
        }
    }
}