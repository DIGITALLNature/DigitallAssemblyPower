// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Runtime.Caching;
using Digitall.APower.Contracts;

namespace Digitall.APower.Services
{
    public class CacheService : ICacheService
    {
        public void SetSliding(string key, object value, int ttl)
        {
            if (ttl < 15)
            {
                ttl = 15;
            }

            MemoryCache.Default.Set(key, value, new CacheItemPolicy { SlidingExpiration = TimeSpan.FromSeconds(ttl) });
        }

        public void SetAbsolute(string key, object value, int ttl)
        {
            if (ttl < 15)
            {
                ttl = 15;
            }

            MemoryCache.Default.Set(key, value, new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(ttl) });
        }

        public bool TryGet(string key, out object value)
        {
            value = MemoryCache.Default.Get(key);
            var hit = value != null;
            return hit;
        }

        public void Remove(string key) => MemoryCache.Default.Remove(key);

        public object this[string key] => MemoryCache.Default[key];

        public bool Contains(string key) => MemoryCache.Default.Contains(key);
    }
}
