using System;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Server;
using Region.Accounting.Domain.Software.License;

namespace Region.Accounting.Application.Software.Commands.CreateSoftwareInstance
{
    public class CreateLicensedSoftwareInstanceCommand : CreateSoftwareInstanceCommand
    {
        public LicenseKey Key { get; }

        public CreateLicensedSoftwareInstanceCommand(Guid softwareId, DateTime installDate, ServerId serverId,
            OrganizationId organizationId, LicenseKey key) : base(softwareId, installDate, serverId, organizationId)
        {
            Key = key;
        }
    }
}