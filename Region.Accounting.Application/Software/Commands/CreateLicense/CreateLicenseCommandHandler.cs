using System;
using Region.Accounting.Application.Common;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Software;
using Region.Mediator;

namespace Region.Accounting.Application.Software.Commands.CreateLicense
{
    public class CreateLicenseCommandHandler : ICommandHandler<CreateLicenseCommand>
    {
        private readonly IRepository _repository;

        public CreateLicenseCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CreateLicenseCommand command)
        {
            var software = _repository.Load<LicensedSoftware>(command.SoftwareId);

            if (software is null)
            {
                throw new Exception("You cannot link a license to non-licensed software");
            }

            software.AddLicense(command.Key, command.DateStart, command.DateEnd,
                OrganizationId.Parse(command.OrganizationId), command.Activations, command.Price, command.Description);

            _repository.Save(software);
        }
    }
}