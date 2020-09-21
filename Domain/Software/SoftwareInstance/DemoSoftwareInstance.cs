using System;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Server;

namespace Region.Accounting.Domain.Software.SoftwareInstance
{
    public class DemoSoftwareInstance : SoftwareInstance
    {
        public DateTime Expiration { get; }

        public DemoSoftwareInstance(SoftwareInstanceId id, DateTime installDate, ServerId serverId,
            OrganizationId organizationId, DateTime expiration) : base(id, installDate, serverId, organizationId)
        {
            Expiration = expiration;
        }
    }
}