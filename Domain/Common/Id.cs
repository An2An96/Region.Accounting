namespace Region.Accounting.Domain.Common
{
    public abstract class Id<T> : ValueObject<Id<T>>
    {
        public T Value { get; }

        protected Id(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}