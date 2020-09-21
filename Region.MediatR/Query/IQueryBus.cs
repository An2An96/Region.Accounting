namespace Region.Mediator.Query
{
    public interface IQueryBus
    {
        TResult Handle<TResult>(IQuery<TResult> query);
    }
}