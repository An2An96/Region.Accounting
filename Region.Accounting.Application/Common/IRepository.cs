using System;
using Region.Accounting.Domain.Common;

namespace Region.Accounting.Application.Common
{
    public interface IRepository
    {
        TAggregate Load<TAggregate>(Guid id)
                where TAggregate : Aggregate;

        TAggregateRole Load<TAggregateRole, TAggregate>(Guid id, IFetchingStrategy<TAggregate, TAggregateRole> fetchingStrategy = null)
            where TAggregate : Aggregate, TAggregateRole
            where TAggregateRole : class;

        void Save<TAggregate>(TAggregate aggregate)
            where TAggregate : Aggregate;

        void Save<TAggregateRole, TAggregate>(TAggregateRole aggregate)
            where TAggregate : Aggregate, TAggregateRole
            where TAggregateRole : class;
    }
}