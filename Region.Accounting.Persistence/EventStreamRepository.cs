using System;
using Region.Accounting.Application.Common;
using Region.Accounting.Domain.Common;

namespace Region.Accounting.Persistence
{
    public class EventStreamRepository : IRepository
    {
        public TAggregate Load<TAggregate>(Guid id) where TAggregate : Aggregate
        {
            return null;
        }

        public TAggregateRole Load<TAggregateRole, TAggregate>(Guid id, IFetchingStrategy<TAggregate, TAggregateRole> fetchingStrategy = null) where TAggregateRole : class where TAggregate : Aggregate, TAggregateRole
        {
            return null;
        }

        public void Save<TAggregate>(TAggregate aggregate) where TAggregate : Aggregate
        {
            
        }

        public void Save<TAggregateRole, TAggregate>(TAggregateRole aggregate) where TAggregateRole : class where TAggregate : Aggregate, TAggregateRole
        {
            
        }
    }
}