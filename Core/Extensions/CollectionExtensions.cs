using System.Collections.Generic;
using System.Linq;

namespace TomatUtilities.Core.Extensions
{
    public static class CollectionExtensions
    {
        public static T[] AddToArray<T>(this T[] array, T item)
        {
            List<T> list = array.ToList();
            list.Add(item);
            return list.ToArray();
        }
    }
}