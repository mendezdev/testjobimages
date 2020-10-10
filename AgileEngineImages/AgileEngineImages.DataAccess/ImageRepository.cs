using System;
using AgileEngineImages.Domain.Entities;
using MongoDB.Driver;

namespace AgileEngineImages.DataAccess
{
    public class ImageRepository : BaseRepository<Image>
    {
        public ImageRepository(IMongoDatabase database): base(database) {}
    }
}
