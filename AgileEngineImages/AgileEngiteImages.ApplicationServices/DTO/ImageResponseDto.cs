using System;
namespace AgileEngiteImages.ApplicationServices.DTO
{
    public class ImageResponseDto
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Tags { get; set; }
        public string Camera { get; set; }
        public string Cropped_Picture { get; set; }
        public string Full_Picture { get; set; }
    }
}
