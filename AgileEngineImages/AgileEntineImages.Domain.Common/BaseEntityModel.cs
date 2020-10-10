using System;
namespace AgileEntineImages.Domain.Common
{
    public abstract class BaseEntityModel<T> : IIdentity<T> where T : class
    {
        public  BaseEntityModel()
        {
        }

        public string id { get; set; }
    }
}
