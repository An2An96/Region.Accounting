using System;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Server;
using Region.Accounting.Domain.Software.SoftwareInstance;

namespace Region.Accounting.Application.Software.Commands.CreateSoftwareInstance
{
    public class CreateDemoSoftwareInstanceCommand : CreateSoftwareInstanceCommand
    {
        public DateTime Expiration { get; }

        public CreateDemoSoftwareInstanceCommand(Guid id, DateTime installDate, ServerId serverId,
            OrganizationId organizationId, DateTime expiration) : base(id, installDate, serverId, organizationId)
        {
            Expiration = expiration;
        }
    }
}