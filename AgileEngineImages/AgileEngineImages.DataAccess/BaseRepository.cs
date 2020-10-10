using System;
using System.Threading.Tasks;
using AgileEngineImages.Domain.Common;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AgileEngineImages.DataAccess
{
    public abstract class BaseRepository<T> where T : IIdentity<T>
    {
        protected IMongoDatabase _database;

        public BaseRepository(IMongoDatabase database)
        {
            _database = database;
            Collection = _database.GetCollection<T>(typeof(T).Name);
        }

        protected IMongoCollection<T> Collection { get; set; }

        protected string CreatedId()
        {
            return ObjectId.GenerateNewId(DateTime.UtcNow).ToString();
        }

        public virtual Task<T> GetByIdAsync(string id)
        {
            return Collection.Find(p => p.Id == id).SingleOrDefaultAsync();
        }

        public virtual Task UpsertAsync(T entity)
        {
            if (entity.Id == null)
            {
                entity.Id = CreatedId();
            }

            return Collection.ReplaceOneAsync(p => p.Id == entity.Id, entity, new ReplaceOptions() { IsUpsert = true });
        }
    }
}
