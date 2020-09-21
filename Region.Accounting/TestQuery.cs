using Region.Mediator.Query;

namespace Region.Mediator
{
    public class TestQuery : IQuery<string>
    {
        public string Value { get; }

        public TestQuery(string value)
        {
            Value = value;
        }
    }
}