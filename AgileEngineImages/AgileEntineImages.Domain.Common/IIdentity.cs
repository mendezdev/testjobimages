using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AgileEntineImages.Domain.Common
{
    public interface IIdentity<T>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string id { get; set; }
    }
}
