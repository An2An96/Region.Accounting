using Region.Accounting.Application.Common;
using Region.Accounting.Domain.Software;
using Region.Mediator;

namespace Region.Accounting.Application.Software.Commands.CreateSoftware
{
    public class CreateSoftwareCommandHandler :
        ICommandHandler<CreateSoftwareCommand>,
        ICommandHandler<CreateLicensedSoftwareCommand>,
        ICommandHandler<CreateOwnSoftwareCommand>
    {
        private readonly IRepository _repository;

        public CreateSoftwareCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CreateSoftwareCommand command)
        {
            var software = new FreeSoftware(command.Vendor, command.Name, command.Type);

            _repository.Save(software);
        }

        public void Handle(CreateLicensedSoftwareCommand command)
        {
            var software = new LicensedSoftware(command.Vendor, command.Name, command.Type);

            _repository.Save(software);
        }

        public void Handle(CreateOwnSoftwareCommand command)
        {
            var software = new OwnSoftware(command.Vendor, command.Name, command.Type);

            _repository.Save(software);
        }
    }
}