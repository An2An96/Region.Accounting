using System;
using Region.Accounting.Domain.Common;

namespace Region.Accounting.Domain.Server
{
    public abstract class Server : Aggregate
    {
//        public ServerId Id { get; }

        protected Server(Guid id)
        {
            Id = id;
        }
    }
}