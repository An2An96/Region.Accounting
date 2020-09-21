using System;
using Region.Accounting.Domain.Common;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Server;
using Region.Accounting.Domain.Software.SoftwareInstance;

namespace Region.Accounting.Domain.Software.Events
{
    public abstract class SoftwareInstanceCreatedEvent : DomainEvent
    {
        public SoftwareInstanceId Id { get; }
        public DateTime InstallDate { get; }
        public ServerId ServerId { get; }
        public OrganizationId OrganizationId { get; }

        protected SoftwareInstanceCreatedEvent(SoftwareInstanceId id, DateTime installDate, ServerId serverId,
            OrganizationId organizationId)
        {
            Id = id;
            InstallDate = installDate;
            ServerId = serverId;
            OrganizationId = organizationId;
        }
    }
}