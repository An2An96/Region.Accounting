using System;
using Region.Mediator.Events;

namespace Region.Mediator
{
    public class TestEventHandler : IEventHandler<TestEvent>
    {
        public void Handle(TestEvent @event)
        {
            Console.WriteLine($"Hello world, {@event.Foo}");
        }
    }
}