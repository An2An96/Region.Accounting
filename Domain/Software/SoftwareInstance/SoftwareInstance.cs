using System;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Server;

namespace Region.Accounting.Domain.Software.SoftwareInstance
{
    public abstract class SoftwareInstance
    {
        public SoftwareInstanceId Id { get; }
        public DateTime InstallDate { get; }
        public ServerId ServerId { get; }
        public OrganizationId OrganizationId { get; }

        protected SoftwareInstance(SoftwareInstanceId id, DateTime installDate, ServerId serverId, OrganizationId organizationId)
        {
            Id = id;
            InstallDate = installDate;
            ServerId = serverId;
            OrganizationId = organizationId;
        }
    }
}