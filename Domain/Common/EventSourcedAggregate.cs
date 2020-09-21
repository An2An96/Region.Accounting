using System.Collections.Generic;

namespace Region.Accounting.Domain.Common
{
    public class EventSourcedAggregate : Aggregate
    {
        private List<DomainEvent> _eventStash;

        public int Version { get; private set; }
        public IEnumerable<DomainEvent> Events => _eventStash;

        /// <summary>
        /// Для создания при загрузке из снапшота
        /// </summary>
        protected EventSourcedAggregate()
        {
        }

        protected void ApplyEvent(DomainEvent @event)
        {
            //  Add DomainEvent wrapper, for add additional info: version, date?

            _eventStash = _eventStash ?? new List<DomainEvent>();

            ChangeState(@event);
            _eventStash.Add(@event);
        }

        private void ChangeState(DomainEvent @event)
        {
            ((dynamic)this).Apply((dynamic)@event);
            Version++;
        }
    }
}