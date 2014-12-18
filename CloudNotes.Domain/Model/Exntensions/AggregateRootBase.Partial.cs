
using Apworks;

// ReSharper disable once CheckNamespace
namespace CloudNotes.Domain.Model
{
    partial class AggregateRootBase
    {
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" }, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj == null)
                return false;
            var aggregateRoot = obj as IAggregateRoot;
            // ReSharper disable once RedundantCast
            if ((object)aggregateRoot == null) return false;
            return this.ID == aggregateRoot.ID;
        }

        /// <summary>
        /// ==s the specified a.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static bool operator ==(AggregateRootBase a, AggregateRootBase b)
        {
            if ((object) a == null && (object) b == null)
                return true;
            if ((object) a == null)
                return false;

            // ReSharper disable once RedundantCast
            return a.Equals(b);
        }

        /// <summary>
        /// !=s the specified a.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static bool operator !=(AggregateRootBase a, AggregateRootBase b)
        {
            return !(a == b);
        }
    }
}
