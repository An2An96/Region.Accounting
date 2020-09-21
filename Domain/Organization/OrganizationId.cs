using System;
using Region.Accounting.Domain.Common;

namespace Region.Accounting.Domain.Organization
{
    public class OrganizationId : Id<Guid>
    {
        public OrganizationId(Guid value) : base(value)
        {
        }

        public static OrganizationId Create()
        {
            return new OrganizationId(Guid.NewGuid());
        }

        public static OrganizationId Parse(string value)
        {
            return new OrganizationId(Guid.Parse(value));
        }

        public static OrganizationId Parse(Guid value)
        {
            return new OrganizationId(value);
        }
    }
}