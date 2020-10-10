using System;
using System.Text.Json.Serialization;

namespace AgileEngineImages.Domain.Entities
{
    public class Picture
    {
        public string Id { get; set; }
        [JsonPropertyName("cropped_picture")]
        public string CroppedPicture { get; set; }
    }
}
