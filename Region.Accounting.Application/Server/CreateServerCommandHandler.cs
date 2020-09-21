using Region.Accounting.Domain.Server;
using Region.Mediator;

namespace Region.Accounting.Application.Server
{
    public class CreateServerCommandHandler : ICommandHandler<CreateVirtualServerCommand>, ICommandHandler<CreateDedicatedServerCommand>
    {
        public CreateServerCommandHandler()
        {
            
        }

        public void Handle(CreateVirtualServerCommand command)
        {
            var server = new VirtualServer(ServerId.Create().Value);
        }

        public void Handle(CreateDedicatedServerCommand command)
        {
            var server = new DedicatedServer(ServerId.Create().Value);
        }
    }
}