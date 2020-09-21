namespace Region.Mediator.Command
{
    public interface ICommandBus
    {
        void Handle<T>(T command) where T: ICommand;
    }
}