using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AgileEngineImages.Domain.Common
{
    public interface IIdentity<T>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
    }
}
