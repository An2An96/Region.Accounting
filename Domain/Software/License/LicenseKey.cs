using System.ComponentModel.DataAnnotations;
using Region.Accounting.Domain.Common;

namespace Region.Accounting.Domain.Software.License
{
    public class LicenseKey : Id<string>
    {
        private LicenseKey(string value) : base(value)
        {
        }

        public static LicenseKey Parse(string value)
        {
            //  todo: package validation?
            if (string.IsNullOrWhiteSpace(value))
                throw new ValidationException("License key can not be empty");

            return new LicenseKey(value);
        }
    }
}