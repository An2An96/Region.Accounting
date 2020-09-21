using System;
using System.Collections.Generic;
using System.Linq;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Server;
using Region.Accounting.Domain.Software.Events;
using Region.Accounting.Domain.Software.License;
using Region.Accounting.Domain.Software.SoftwareInstance;

namespace Region.Accounting.Domain.Software
{
    //  todo: как будет выглядеть снапшот этого аггрегата? (опять же внутри может быть тысячи softwareInstance и license)
    public class LicensedSoftware : Software
    {
        private List<License.License> _licenses = new List<License.License>();

        public IEnumerable<License.License> Licenses => _licenses;

        public LicensedSoftware(string vendor, string name, SoftwareType type) : base(vendor, name, type)
        {
        }

        public void AddLicense(LicenseKey key, DateTime dateStart, DateTime dateEnd, OrganizationId organizationId, int activations,
            int price, string description)
        {
            Apply(new LicenseCreatedEvent(key, dateStart, dateEnd, organizationId, activations, price, description));
        }

        public void AddInstance(DateTime installDate, ServerId serverId, OrganizationId organizationId, LicenseKey key)
        {
            var license = Licenses.First(x => x.Key.Equals(key));

            if (license is null)
            {
                //  todo: use domain exception
                throw new Exception("This key not exist");
            }

            if (license.ActivationsInstances.Count() >= license.ActivationsCount)
            {
                //  todo: use domain exception
                throw new Exception("This license has a maximum number of copies");
            }

            if (!license.OrganizationId.Equals(organizationId))
            {
                //  todo: use domain exception
                throw new Exception("You cannot apply the license of someone else's organization");
            }

            Apply(new LicensedSoftwareInstanceCreatedEvent(SoftwareInstanceId.Create(), installDate, serverId,
                organizationId, key));
        }

        public void AddDemoInstance(DateTime installDate, ServerId serverId, OrganizationId organizationId,
            DateTime expiration)
        {
            Apply(new DemoSoftwareInstanceCreatedEvent(SoftwareInstanceId.Create(), installDate, serverId,
                organizationId, expiration));
        }

        #region ApplyEvent Events

        private void Apply(LicenseCreatedEvent @event)
        {
            var license = new License.License(@event.Key, @event.DateStart, @event.DateEnd, @event.OrganizationId,
                @event.Activations, @event.Price, @event.Description);

            _licenses.Add(license);
        }

        private void Apply(LicensedSoftwareInstanceCreatedEvent @event)
        {
            //  todo: question
            var license = Licenses.Single(x => x.Key.Equals(@event.Key));

            var instance = new LicensedSoftwareInstance(@event.Id, @event.InstallDate, @event.ServerId,
                @event.OrganizationId, license);

            _instances.Add(instance);
        }

        private void Apply(DemoSoftwareInstanceCreatedEvent @event)
        {
            var instance = new DemoSoftwareInstance(SoftwareInstanceId.Create(), @event.InstallDate, @event.ServerId,
                @event.OrganizationId, @event.Expiration);

            _instances.Add(instance);
        }

        #endregion
    }
}