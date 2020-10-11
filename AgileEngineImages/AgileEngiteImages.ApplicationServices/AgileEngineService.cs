using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AgileEngineImages.Common;
using AgileEngineImages.Domain.DTO;
using AgileEngineImages.Domain.Entities;
using Newtonsoft.Json;

namespace AgileEngiteImages.ApplicationServices
{
    public class AgileEngineService
    {
        private readonly ImageService _imageService;
        private const string URI_IMAGES = "http://interview.agileengine.com:80";
        private readonly HttpClient _httpClient;
        private const string API_KEY = "23567b218376f79d9415";

        public AgileEngineService(HttpClient httpClient, ImageService imageService)
        {
            _httpClient = httpClient;
            _imageService = imageService;
        }

        public virtual async Task<ImagePagination> GetImages()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{URI_IMAGES}/images");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ImagePagination>(content);
            }

            return null;
        }

        public virtual async Task<Image> GetImageByIdAsync(string id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{URI_IMAGES}/images/{id}");
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.Unauthorized:
                    await GetToken();
                    return await GetImageByIdAsync(id);
                case System.Net.HttpStatusCode.OK:
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Image>(content);
                default:
                    return null;
            }
        }

        public virtual async Task<AuthDto> GetToken()
        {
            string jsonString = JsonConvert.SerializeObject(new { apiKey = API_KEY });
            var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync($"{URI_IMAGES}/auth", payload);
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
