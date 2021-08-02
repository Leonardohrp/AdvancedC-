using System;
using System.Collections.Generic;
using System.Text;

namespace LinqInternals.Demo.Select
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<TResult> NewSelect<T, TResult>(this IEnumerable<T> items, Func<T, TResult> selector)
        {
            foreach (var item in items)
            {
                yield return selector(item);
            }
        }
    }
}
