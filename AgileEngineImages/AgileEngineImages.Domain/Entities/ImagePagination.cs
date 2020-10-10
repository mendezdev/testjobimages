using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AgileEngineImages.Domain.Entities
{
    public class ImagePagination
    {
        public List<Picture> Pictures { get; set; }
        public int Page { get; set; }
        [JsonPropertyName("pageCount")]
        public int PageCount { get; set; }
        public bool HasMore { get; set; }
    }
}
