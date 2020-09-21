using Region.Accounting.Application.Software.Commands.CreateSoftware;
using Region.Mediator.Events;

namespace Region.Mediator
{
    public class TestCommandHandler : ICommandHandler<CreateLicensedSoftwareCommand>
    {
        private readonly IEventBus _eventBus;

        public TestCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Handle(CreateLicensedSoftwareCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}