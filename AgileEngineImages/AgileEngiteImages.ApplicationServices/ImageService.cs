using System.Collections.Generic;
using System.Threading.Tasks;
using AgileEngineImages.DataAccess;
using AgileEngineImages.Domain.Entities;

namespace AgileEngiteImages.ApplicationServices
{
    public class ImageService
    {
        private readonly ImageRepository _imageRepository;
        
        public ImageService(ImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public virtual Task Store(Image image)
        {
            return _imageRepository.UpsertAsync(image);
        }

        public virtual Task<Image> Get(string id)
        {
            return _imageRepository.GetByIdAsync(id);
        }

        public virtual Task<List<Image>> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return Task.FromResult(new List<Image>());
            }
            return _imageRepository.Search(searchTerm);
        }
    }
}
