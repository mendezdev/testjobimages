using System;
using AgileEngineImages.Domain.Entities;
using AgileEngiteImages.ApplicationServices.DTO;

namespace AgileEngiteImages.ApplicationServices.Mappers
{
    public class ImageMapper : IMapper<Image, ImageResponseDto>
    {
        public Image From(ImageResponseDto obj)
        {
            return new Image
            {
                Id = obj.Id,
                Author = obj.Author,
                Camera = obj.Camera,
                Tags = obj.Tags,
                CroppedPicture = obj.Cropped_Picture,
                FullPicture = obj.Full_Picture
            };
        }
    }
}
