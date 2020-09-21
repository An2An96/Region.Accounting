using System;

namespace Region.Accounting.Domain.Common
{
    public abstract class Aggregate : Entity<Guid>
    {
        public Guid Id { get; protected set; }


        protected Aggregate()
        {

        }

        protected Aggregate(Guid id)
        {
            Id = id;
        }

        protected override Guid GetKey()
        {
            return Id;
        }
    }
}