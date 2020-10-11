using System.Text.Json.Serialization;

namespace AgileEngineImages.Domain.DTO
{
    public class AuthDto
    {
        [JsonPropertyName("auth")]
        public string Auth { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
