using System.Collections.Generic;
using System.Linq;


public static class EnumerableExtensions
{
    public static string AsString(this IEnumerable<int> source)
    {
        return "<IEnumerable>{" + string.Join(", ", source) + "}";
    }
}