using System.Collections.Generic;
using Region.Accounting.Domain.Common;

namespace Region.Accounting.Domain.Software
{
    public abstract class Software : EventSourcedAggregate
    {
        protected readonly List<SoftwareInstance.SoftwareInstance> _instances = new List<SoftwareInstance.SoftwareInstance>();

        public string Vendor { get; }
        public string Name { get; }
        public SoftwareType Type { get; }
        public IEnumerable<SoftwareInstance.SoftwareInstance> Instances => _instances;

        protected Software(string vendor, string name, SoftwareType type)
        {
            Vendor = vendor;
            Name = name;
            Type = type;
        }
    }
}
