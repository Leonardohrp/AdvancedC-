using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryCache.Demo
{
    public class UserCache : IUserCache
    {
        private const string KEY = "user_cache";
        private readonly IMemoryCache memoryCache;

        public UserCache(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public void AddToCache(User[] users)
        {
            var option = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(30),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(90)
            };

            // Get data from a database
            memoryCache.Set<User[]>(KEY, users, option);
        }

        public User[] GetCachedUsers()
        {
            User[] users;
            if (!memoryCache.TryGetValue(KEY, out users))
            {
                users = new User[] {
                    new User{ Name = "Leo1", Age = 22 },
                    new User{ Name = "Leo2", Age = 23 },
                    new User{ Name = "Leo3", Age = 26 }
                };
                AddToCache(users);
            }
            return memoryCache.Get<User[]>(KEY);
        }
    }
}
