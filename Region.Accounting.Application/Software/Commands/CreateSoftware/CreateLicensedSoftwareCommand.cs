using Region.Accounting.Domain.Software;

namespace Region.Accounting.Application.Software.Commands.CreateSoftware
{
    public class CreateLicensedSoftwareCommand : CreateSoftwareCommand
    {
        public CreateLicensedSoftwareCommand(string vendor, string name, SoftwareType type) : base(vendor, name, type)
        {
        }
    }
}