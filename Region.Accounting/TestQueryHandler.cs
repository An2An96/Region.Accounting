using System;
using Region.Mediator.Query;

namespace Region.Mediator
{
    public class TestQueryHandler : IQueryHandler<TestQuery, string>
    {
        public string Handle(TestQuery query)
        {
            return query.Value + Guid.NewGuid();
        }
    }
}