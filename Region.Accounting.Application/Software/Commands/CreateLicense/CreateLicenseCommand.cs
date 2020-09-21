using System;
using Region.Accounting.Domain.Software.License;
using Region.Mediator;

namespace Region.Accounting.Application.Software.Commands.CreateLicense
{
    public class CreateLicenseCommand : ICommand
    {
        public Guid SoftwareId { get; }
        public LicenseKey Key { get; }
        public DateTime DateStart { get; }
        public DateTime DateEnd { get; }
        public Guid OrganizationId { get; }
        public int Activations { get; }
        public int Price { get; }
        public string Description { get; }

        public CreateLicenseCommand(Guid softwareId, LicenseKey key, DateTime dateStart, DateTime dateEnd,
            Guid organizationId, int activations, int price, string description)
        {
            SoftwareId = softwareId;
            Key = key;
            DateStart = dateStart;
            DateEnd = dateEnd;
            OrganizationId = organizationId;
            Activations = activations;
            Price = price;
            Description = description;
        }
    }
}