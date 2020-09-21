using Region.Accounting.Domain.Software;

namespace Region.Accounting.Application.Software.Commands.CreateSoftware
{
    public class CreateFreeSoftwareCommand : CreateSoftwareCommand
    {
        public CreateFreeSoftwareCommand(string vendor, string name, SoftwareType type) : base(vendor, name, type)
        {
        }
    }
}