using System;
using Region.Accounting.Domain.Common;

namespace Region.Accounting.Domain.Server
{
    public class ServerId : Id<Guid>
    {
        public ServerId(Guid value) : base(value)
        {
        }

        public static ServerId Create()
        {
            return new ServerId(Guid.NewGuid());
        }
    }
}