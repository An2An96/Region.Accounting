using System;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Server;
using Region.Accounting.Domain.Software.Events;
using Region.Accounting.Domain.Software.SoftwareInstance;

namespace Region.Accounting.Domain.Software
{
    public class FreeSoftware : Software
    {
        public FreeSoftware(string vendor, string name, SoftwareType type) : base(vendor, name, type)
        {
        }

        public void AddInstance(DateTime installDate, ServerId serverId, OrganizationId organizationId)
        {
            var instance = new FreeSoftwareInstance(SoftwareInstanceId.Create(), installDate, serverId, organizationId);

            _instances.Add(instance);

            ApplyEvent(new FreeSoftwareInstanceCreatedEvent(instance.Id, instance.InstallDate, instance.ServerId,
                instance.OrganizationId));
        }
    }
}