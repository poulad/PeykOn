using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

// ReSharper disable MemberCanBePrivate.Global
namespace PeykOn.Helpers
{
    public static class Extensions
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
                        c = (char) random.Next(48, 50);
                        break;
                    case 1: // Upper-Case Letter
                        c = (char) random.Next(65, 91);
                        break;
                    case 2: // Lower-Case Letter
                        c = (char) random.Next(97, 123);
                        break;
                }
                yield return c;
            }
        }

        public static Task SetObjectAsync(this IDistributedCache cache, string key, object value,
            CancellationToken cancellationToken = default(CancellationToken)) =>
            cache.SetStringAsync(key, JsonConvert.SerializeObject(value, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            }), cancellationToken);

        public static Task SetObjectAsync(this IDistributedCache cache, string key, object value,
            DistributedCacheEntryOptions options,
            CancellationToken cancellationToken = default(CancellationToken)) =>
            cache.SetStringAsync(key, JsonConvert.SerializeObject(value, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            }), options, cancellationToken);

        public static Task<(bool HasValue, T Value)> GetObjectAsync<T>(this IDistributedCache cache, string key,
            CancellationToken cancellationToken = default(CancellationToken)) =>
            cache.GetStringAsync(key, cancellationToken)
                .ContinueWith(t => t.Result is null
                    ? (false, default(T))
                    : (true, JsonConvert.DeserializeObject<T>(t.Result)));

        public static Task<(bool HasValue, object Value)> GetObjectAsync(this IDistributedCache cache, string key,
            CancellationToken cancellationToken = default(CancellationToken)) =>
            cache.GetObjectAsync<object>(key, cancellationToken);

        public static Task<(bool Exists, object ExistingValue)> SetObjectIfNotExistsAsync(this IDistributedCache cache,
            string key, object value, CancellationToken cancellationToken = default(CancellationToken)) =>
            cache.GetObjectAsync(key, cancellationToken)
                .ContinueWith(t => t.Result.HasValue
                    ? (true, t.Result.Value)
                    : cache.SetObjectAsync(key, value, cancellationToken)
                        .ContinueWith(t2 => (false, default(object)), cancellationToken).Result
                );

        public static Task<(bool Exists, object ExistingValue)> SetObjectIfNotExistsAsync(this IDistributedCache cache,
            string key, object value, DistributedCacheEntryOptions options,
            CancellationToken cancellationToken = default(CancellationToken)) =>
            cache.GetObjectAsync(key, cancellationToken)
                .ContinueWith(t => t.Result.HasValue
                    ? (true, t.Result.Value)
                    : cache.SetObjectAsync(key, value, options, cancellationToken)
                        .ContinueWith(t2 => (false, default(object)), cancellationToken).Result
                );
    }
}