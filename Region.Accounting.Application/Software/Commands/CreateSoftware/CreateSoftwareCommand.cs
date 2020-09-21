using Region.Accounting.Domain.Software;
using Region.Mediator;

namespace Region.Accounting.Application.Software.Commands.CreateSoftware
{
    public abstract class CreateSoftwareCommand : ICommand
    {
        public string Vendor { get; }
        public string Name { get; }
        public SoftwareType Type { get; }

        protected CreateSoftwareCommand(string vendor, string name, SoftwareType type)
        {
            Vendor = vendor;
            Name = name;
            Type = type;
        }
    }
}