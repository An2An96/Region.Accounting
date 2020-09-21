using System;
using Region.Accounting.Domain.Common;

namespace Region.Accounting.Domain.Software.SoftwareInstance
{
    //  todo: complete
    public class SoftwareInstanceId : Id<Guid>
    {
        private SoftwareInstanceId(Guid value) : base(value)
        {
        }

        public static SoftwareInstanceId Create()
        {
            return new SoftwareInstanceId(Guid.NewGuid());
        }
    }
}