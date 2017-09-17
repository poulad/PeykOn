using System;
using System.Collections.Generic;
using System.Linq;

namespace PeykOn.Helpers
{
    public static class Helpers
    {
        public static string GenerateAlphanumericString(int count) => string.Join("",
                Enumerable.Range(0, count)
                    .GenerateAlphanumericCharacters(new Random(DateTime.UtcNow.Millisecond))
                    .ToArray()
            );

        public static IEnumerable<char> GenerateAlphanumericCharacters<T>(this IEnumerable<T> enumerable, Random random)
        {
            foreach (var _ in enumerable)
            {
                char c = default(char);
                int charType = random.Next() % 3;
                switch (charType)
                {
                    case 0: // Number
                        c = (char)random.Next(48, 50);
                        break;
                    case 1: // Upper-Case Letter
                        c = (char)random.Next(65, 91);
                        break;
                    case 2: // Lower-Case Letter
                        c = (char)random.Next(97, 123);
                        break;
                }
                yield return c;
            }
        }
    }
}
