using System.Net.Http;
using System.Threading.Tasks;
using AgileEngineImages.Common;
using AgileEngineImages.Domain.Entities;

namespace AgileEngiteImages.ApplicationServices
{
    public class AgileEngineService
    {
        private readonly ImageService _imageService;
        private const string URI_IMAGES = "http://interview.agileengine.com:80/images";
        private readonly HttpClient _httpClient;
        private readonly Serializer<ImagePagination> _serializer;

        public AgileEngineService(HttpClient httpClient, ImageService imageService)
        {
            _httpClient = httpClient;
            _imageService = imageService;
            _serializer = new Serializer<ImagePagination>();
        }

        public virtual async Task<ImagePagination> GetImages()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(URI_IMAGES);
            if (response.IsSuccessStatusCode)
            {
                byte[] content = await response.Content.ReadAsByteArrayAsync();
                return _serializer.Deserialize(content);
            }

            return null;
        }
    }
}
