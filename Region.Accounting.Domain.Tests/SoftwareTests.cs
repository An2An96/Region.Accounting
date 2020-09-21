using System;
using System.Linq;
using NUnit.Framework;
using Region.Accounting.Domain.Organization;
using Region.Accounting.Domain.Software;
using Region.Accounting.Domain.Software.Events;
using Region.Accounting.Domain.Software.License;

namespace Region.Accounting.Domain.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var software = new LicensedSoftware("Microsoft", "Visual Studio 2019", SoftwareType.User);

            software.AddLicense(LicenseKey.Parse("test key"), DateTime.Now, DateTime.Now.AddDays(365),
                OrganizationId.Create(), 10, 1000, "Test description");

            
            var @event = software.Events.FirstOrDefault();
            
            Assert.IsAssignableFrom<LicenseCreatedEvent>(@event);

            var eventCreatedLicense = @event as LicenseCreatedEvent;

            software.AddLicense(eventCreatedLicense.Key, eventCreatedLicense.DateStart, eventCreatedLicense.DateEnd,
                eventCreatedLicense.OrganizationId, eventCreatedLicense.Activations, eventCreatedLicense.Price,
                eventCreatedLicense.Description);

//            software.Licenses.First((x, i) => i == 0)
//
//            Assert.AreEqual(originalLicense.Key, copyLicense.Key);
//            Assert.AreEqual(originalLicense.ActivationsCount, copyLicense.ActivationsCount);
        }
    }
}