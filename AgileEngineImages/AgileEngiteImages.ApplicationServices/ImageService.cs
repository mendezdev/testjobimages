using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using AgileEngineImages.DataAccess;
using AgileEngineImages.Domain.Entities;

namespace AgileEngiteImages.ApplicationServices
{
    public class ImageService
    {
        private readonly Repository _repository;
        
        public ImageService(Repository repository)
        {
            _repository = repository;
        }

        public virtual Task Store(Image image)
        {
            return _repository.Create(image.Id, Serialize(image));
        }

        public virtual async Task<Image> Get(string id)
        {
            byte[] result = await _repository.Get(id);
            return Deserialize(result);
        }

        private byte[] Serialize(Image image)
        {
            if (image == null)
            {
                return null;
            }

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, image);
            return ms.ToArray();
        }

        private Image Deserialize(byte[] arrBytes)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            ms.Write(arrBytes, 0, arrBytes.Length);
            ms.Seek(0, SeekOrigin.Begin);
            Image image = (Image)bf.Deserialize(ms);
            return image;
        }
    }
}
