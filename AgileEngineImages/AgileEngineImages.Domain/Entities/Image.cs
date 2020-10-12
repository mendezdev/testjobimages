using System;
using System.Text.Json.Serialization;
using AgileEngineImages.Domain.Common;

namespace AgileEngineImages.Domain.Entities
{
    public class Image : BaseEntityModel<Image>
    {
        public string Author { get; set; }
        public string Tags { get; set; }
        public string Camera { get; set; }
        [JsonPropertyName("cropped_picture")]
        public string CroppedPicture { get; set; }
        [JsonPropertyName("full_picture")]
        public string FullPicture { get; set; }
    }
}
