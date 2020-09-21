using System;
using Microsoft.Extensions.DependencyInjection;
using Region.Mediator.Command;

namespace Region.Mediator.MicrosoftContainerImplementation
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceProvider _provider;

        public CommandBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void Handle<T>(T command) where T : ICommand
        {
            using var scope = _provider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<T>>();
            handler.Handle(command);
        }
    }
}