using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Domain.Extensions
{
    
    public static class Extension
    {
        public static IEnumerable<IEnumerable<T>> FindConsecutiveGroups<T>(this IEnumerable<T> sequence, Predicate<T> predicate, int count)
        {
            IEnumerable<T> current = sequence;

            while (current.Count() > count)
            {
                IEnumerable<T> window = current.Take(count);

                if (window.Where(x => predicate(x)).Count() >= count)
                    yield return window;

                current = current.Skip(1);
            }
        }
    }
}
