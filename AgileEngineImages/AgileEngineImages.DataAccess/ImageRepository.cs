using System.Collections.Generic;
using System.Threading.Tasks;
using AgileEngineImages.Domain.Entities;
using MongoDB.Driver;

namespace AgileEngineImages.DataAccess
{
    public class ImageRepository : BaseRepository<Image>
    {
        public ImageRepository(IMongoDatabase database): base(database) {}

        //TODO: improved this search, I tried but couldn't because of limit time --> sorry :(
        public virtual Task<List<Image>> Search(string searchTerm)
        {
            return Collection.Find(p => p.Author == searchTerm || p.Tags == searchTerm || p.Camera == searchTerm || p.CroppedPicture == searchTerm || p.FullPicture == searchTerm).ToListAsync();
        }
    }
}
