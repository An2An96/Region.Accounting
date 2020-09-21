using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Region.Accounting.Domain.Common
{
    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {
        public bool Equals(T other)
        {
            return Equals((object)other);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return GetFields().All(field => FieldEquals(field, (T)obj));
        }

        private bool FieldEquals(FieldInfo field, T other)
        {
            var otherValue = field.GetValue(other);
            var thisValue = field.GetValue(this);

            if (ReferenceEquals(thisValue, otherValue)) return true;

            if (thisValue == null || otherValue == null) return false;

            return thisValue.Equals(otherValue);
        }

        public override int GetHashCode()
        {
            const int startValue = 17;
            const int multiplier = 59;

            var hashCode = startValue;

            foreach (var field in GetFields())
            {
                var value = field.GetValue(this);

                if (value != null)
                    hashCode = hashCode * multiplier + value.GetHashCode();
            }

            return hashCode;
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            var t = GetType();

            var fields = new List<FieldInfo>();

            while (t != typeof(object))
            {
                fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));

                t = t.BaseType;
            }

            return fields;
        }

        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
        {
            return x?.Equals(y) ?? y is null;
        }

        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
        {
            return !(x == y);
        }
    }
}