using System;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Server;

namespace Region.Accounting.Application.Software.Commands.CreateSoftwareInstance
{
    public class CreateFreeSoftwareInstanceCommand : CreateSoftwareInstanceCommand
    {
        public CreateFreeSoftwareInstanceCommand(Guid softwareId, DateTime installDate, ServerId serverId,
            OrganizationId organizationId) : base(softwareId, installDate, serverId, organizationId)
        {
        }
    }
}