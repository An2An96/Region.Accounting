using System;
using Region.Accounting.Application.Common;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Software;
using Region.Mediator;

namespace Region.Accounting.Application.Software.Commands.CreateSoftwareInstance
{
    public class CreateSoftwareInstanceCommandHandler :
        ICommandHandler<CreateFreeSoftwareInstanceCommand>,
        ICommandHandler<CreateDemoSoftwareInstanceCommand>,
        ICommandHandler<CreateLicensedSoftwareInstanceCommand>
    {
        private readonly IRepository _repository;

        public CreateSoftwareInstanceCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CreateFreeSoftwareInstanceCommand command)
        {
            var software = _repository.Load<FreeSoftware>(command.SoftwareId);

            if (software is null)
            {
                throw new Exception("This software is not free");
            }

            CheckRelatedAggregates(command);

            software.AddInstance(command.InstallDate, command.ServerId, command.OrganizationId);

            _repository.Save(software);
        }

        public void Handle(CreateDemoSoftwareInstanceCommand command)
        {
            var software = _repository.Load<LicensedSoftware>(command.SoftwareId);

            if (software is null)
            {
                throw new Exception("This software is not licensed");
            }

            CheckRelatedAggregates(command);

            software.AddDemoInstance(command.InstallDate, command.ServerId, command.OrganizationId, command.Expiration);

            _repository.Save(software);
        }

        public void Handle(CreateLicensedSoftwareInstanceCommand command)
        {
            var software = _repository.Load<LicensedSoftware>(command.SoftwareId);

            if (software is null)
            {
                throw new Exception("This software is not licensed");
            }

            CheckRelatedAggregates(command);

            software.AddInstance(command.InstallDate, command.ServerId, command.OrganizationId, command.Key);

            _repository.Save(software);
        }

        private void CheckRelatedAggregates(CreateSoftwareInstanceCommand command)
        {
            var server = _repository.Load<Domain.Server.Server>(command.ServerId.Value);

            if (server is null)
            {
                throw new Exception("Non-existent server specified");
            }

            var organization = _repository.Load<Organization>(command.OrganizationId.Value);

            if (organization is null)
            {
                throw new Exception("Non-existent organization indicated");
            }
        }
    }
}