using System;
namespace AgileEngineImages.Domain.Common
{
    public abstract class BaseEntityModel<T> : IIdentity<T> where T : class
    {
        public BaseEntityModel()
        {
        }

        public string Id { get; set; }
    }
}
