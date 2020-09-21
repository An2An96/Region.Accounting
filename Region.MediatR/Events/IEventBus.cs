namespace Region.Mediator.Events
{
    public interface IEventBus
    {
        void Handle<TEvent>(TEvent @event) where TEvent: IEvent;
    }
}