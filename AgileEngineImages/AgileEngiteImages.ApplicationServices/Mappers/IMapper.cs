using System;
namespace AgileEngiteImages.ApplicationServices.Mappers
{
    public interface IMapper<A, B>
    {
        A From(B obj);
    }
}
