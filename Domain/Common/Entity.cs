using System;

namespace Region.Accounting.Domain.Common
{
    public abstract class Entity<TKey> : IEquatable<Entity<TKey>>
    {
        protected abstract TKey GetKey();

        #region Compare

        public bool Equals(Entity<TKey> other)
        {
            return Equals((object)other);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return GetKey().Equals(((Entity<TKey>)obj).GetKey());
        }

        public override int GetHashCode()
        {
            return GetKey().GetHashCode();
        }

        public static bool operator ==(Entity<TKey> x, Entity<TKey> y)
        {
            return x?.Equals(y) ?? y is null;
        }

        public static bool operator !=(Entity<TKey> x, Entity<TKey> y)
        {
            return !(x == y);
        }

        #endregion
    }
}