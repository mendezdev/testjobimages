using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AgileEngineImages.Domain.DTO;
using AgileEngineImages.Domain.Entities;
using AgileEngiteImages.ApplicationServices.Config;
using Newtonsoft.Json;

namespace AgileEngiteImages.ApplicationServices
{
    public class AgileEngineService
    {
        private readonly ImageService _imageService;
        private readonly HttpClient _httpClient;
        private readonly AuthConfig _authConfig;

        public AgileEngineService(HttpClient httpClient, AuthConfig authConfig, ImageService imageService)
        {
            _httpClient = httpClient;
            _authConfig = authConfig;
            _imageService = imageService;
        }

        public virtual async Task<ImagePagination> GetImages(int page)
        {
            var uri = $"{_authConfig.BaseUri}/images";
            uri = page != 0 ? $"{uri}?page={page}" : uri;
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            switch(response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    await GetToken();
                    return await GetImages(page);
                case HttpStatusCode.OK:
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ImagePagination>(content);
                default:
                    return null;
            }
        }

        public virtual async Task<Image> GetImageByIdAsync(string id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_authConfig.BaseUri}/images/{id}");
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    await GetToken();
                    return await GetImageByIdAsync(id);
                case HttpStatusCode.OK:
                    string content = await response.Content.ReadAsStringAsync();
                    var imageResult = JsonConvert.DeserializeObject<Image>(content);
                    await _imageService.Store(imageResult);
                    return imageResult;
                default:
                    return null;
            }
        }

        public virtual async Task<AuthDto> GetToken()
        {
            string jsonString = JsonConvert.SerializeObject(new { apiKey = _authConfig.APIKey });
            var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync($"{_authConfig.BaseUri}/auth", payload);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                AuthDto authResult = JsonConvert.DeserializeObject<AuthDto>(content);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.Token);
                return authResult;
            }

            return null;
        }
    }
}
