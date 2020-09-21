using System;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Server;
using Region.Mediator;

namespace Region.Accounting.Application.Software.Commands.CreateSoftwareInstance
{
    public class CreateSoftwareInstanceCommand : ICommand
    {
        public Guid SoftwareId { get; }
        public DateTime InstallDate { get; }
        public ServerId ServerId { get; }
        public OrganizationId OrganizationId { get; }

        public CreateSoftwareInstanceCommand(Guid softwareId, DateTime installDate, ServerId serverId,
            OrganizationId organizationId)
        {
            SoftwareId = softwareId;
            InstallDate = installDate;
            ServerId = serverId;
            OrganizationId = organizationId;
        }
    }
}