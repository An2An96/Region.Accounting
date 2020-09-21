using System;
using System.Collections.Generic;
using Region.Accounting.Domain.Common;
using Region.Accounting.Domain.Organization;

namespace Region.Accounting.Domain.Software.License
{
    public class License : Entity<LicenseKey>
    {
        public LicenseKey Key { get; }
        public DateTime DateStart { get; }
        public DateTime DateEnd { get; }
        public OrganizationId OrganizationId { get; }
        public int ActivationsCount { get; }
        public int Price { get; }   //  todo: use Money value object
        public string Description { get; }

        public IEnumerable<SoftwareInstance.SoftwareInstance> ActivationsInstances => _activationsInstances;

        private readonly List<SoftwareInstance.SoftwareInstance> _activationsInstances = new List<SoftwareInstance.SoftwareInstance>();

        public License(LicenseKey key, DateTime dateStart, DateTime dateEnd, OrganizationId organizationId, int activationsCount,
            int price, string description)
        {
            Key = key;
            DateStart = dateStart;
            DateEnd = dateEnd;
            OrganizationId = organizationId;
            ActivationsCount = activationsCount;
            Price = price;
            Description = description;
        }

        protected override LicenseKey GetKey()
        {
            return Key;
        }
    }
}