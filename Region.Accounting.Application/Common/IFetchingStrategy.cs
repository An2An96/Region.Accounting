using Region.Accounting.Domain.Common;

namespace Region.Accounting.Application.Common
{
    public interface IFetchingStrategy<TAggregate, TAggregateRole>
        where TAggregate : Aggregate, TAggregateRole
        where TAggregateRole : class
    {
    }
}