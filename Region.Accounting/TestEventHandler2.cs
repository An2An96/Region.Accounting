using Region.Mediator.Events;

namespace Region.Mediator
{
    public class TestEventHandler2 : IEventHandler<TestEvent>
    {
        public void Handle(TestEvent @event)
        {
            var a = @event.Foo;
        }
    }
}