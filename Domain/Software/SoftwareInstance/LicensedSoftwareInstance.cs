using System;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Server;

namespace Region.Accounting.Domain.Software.SoftwareInstance
{
    public class LicensedSoftwareInstance : SoftwareInstance
    {
        public License.License License { get; }

        public LicensedSoftwareInstance(SoftwareInstanceId id, DateTime installDate, ServerId serverId,
            OrganizationId organizationId, License.License license) : base(id, installDate, serverId, organizationId)
        {
            License = license;
        }
    }
}