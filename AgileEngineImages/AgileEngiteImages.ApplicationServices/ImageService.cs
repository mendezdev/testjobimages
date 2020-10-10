using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using AgileEngineImages.DataAccess;
using AgileEngineImages.Domain.Entities;
using AgileEngineImages.Common;

namespace AgileEngiteImages.ApplicationServices
{
    public class ImageService
    {
        private readonly Repository _repository;
        private readonly Serializer<Image> _serializer;
        
        public ImageService(Repository repository)
        {
            _repository = repository;
            _serializer = new Serializer<Image>();
        }

        public virtual Task Store(Image image)
        {
            return _repository.Create(image.Id, _serializer.Serialize(image));
        }

        public virtual async Task<Image> Get(string id)
        {
            return _serializer.Deserialize(await _repository.Get(id));
        }
    }
}
