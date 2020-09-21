using System;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Server;

namespace Region.Accounting.Domain.Software.SoftwareInstance
{
    public class FreeSoftwareInstance : SoftwareInstance
    {
        public FreeSoftwareInstance(SoftwareInstanceId id, DateTime installDate, ServerId serverId,
            OrganizationId organizationId) : base(id, installDate, serverId, organizationId)
        {
        }
    }
}