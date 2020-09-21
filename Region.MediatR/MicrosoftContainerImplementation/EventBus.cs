using System;
using Microsoft.Extensions.DependencyInjection;
using Region.Mediator.Events;

namespace Region.Mediator.MicrosoftContainerImplementation
{
    public class EventBus : IEventBus
    {
        private readonly IServiceProvider _provider;

        public EventBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void Handle<TEvent>(TEvent @event) where TEvent : IEvent
        {
            using var scope = _provider.CreateScope();

            var handlers = scope.ServiceProvider.GetServices<IEventHandler<TEvent>>();

            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}