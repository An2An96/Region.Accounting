using Region.Mediator.Events;

namespace Region.Mediator
{
    public class TestEvent : IEvent
    {
        public string Foo = "Bar";
    }
}