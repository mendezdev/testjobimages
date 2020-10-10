using System;

namespace AgileEngineImages.Domain.Entities
{
    public class Image
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Tags { get; set; }
        public string CroppedPicture { get; set; }
        public string FullPicture { get; set; }
    }
}
