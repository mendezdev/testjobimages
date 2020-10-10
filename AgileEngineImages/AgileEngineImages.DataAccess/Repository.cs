using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace AgileEngineImages.DataAccess
{
    public class Repository
    {
        private readonly IDistributedCache _cache;

        public virtual Task<byte[]> Get(string key)
        {
            return _cache.GetAsync(key);
        }

        public virtual Task Create(string key, byte[] data)
        {
            return _cache.SetAsync(key, data);
        }
    }
}
