using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciPro.Tests.Extensions
{
    public static class IEnumerableExtensions
    {
        public static TSource SecondLast<TSource>(this IEnumerable<TSource> source)
        {
            return source.ToList()[source.Count() - 2];
        }
    }
}
