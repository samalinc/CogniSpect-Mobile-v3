using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<TItem>([CanBeNull] this IEnumerable<TItem> items)
        {
            return items == null || !items.Any();
        }
    }
}