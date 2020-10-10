using System;
using System.Collections.Generic;

namespace AgileEngineImages.Domain.Entities
{
    public class ImagePagination
    {
        public List<Picture> Pictures { get; set; }
        public int Page { get; set; }
        public int PageCount { get; set; }
        public bool HasMore { get; set; }
    }
}
