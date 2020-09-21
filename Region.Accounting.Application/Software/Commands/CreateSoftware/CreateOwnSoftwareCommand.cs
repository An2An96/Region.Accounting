using Region.Accounting.Domain.Software;

namespace Region.Accounting.Application.Software.Commands.CreateSoftware
{
    public class CreateOwnSoftwareCommand : CreateSoftwareCommand
    {
        public CreateOwnSoftwareCommand(string vendor, string name, SoftwareType type) : base(vendor, name, type)
        {
        }
    }
}