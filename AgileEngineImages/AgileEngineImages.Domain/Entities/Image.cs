using System;
using System.Text.Json.Serialization;

namespace AgileEngineImages.Domain.Entities
{
    public class Image
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Tags { get; set; }
        [JsonPropertyName("cropped_picture")]
        public string CroppedPicture { get; set; }
        [JsonPropertyName("full_picture")]
        public string FullPicture { get; set; }
    }
}
