using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AgileEngineImages.Common
{
    public static class Serializer<T> where T : class
    {
        public static byte[] Serialize(T entity)
        {
            if (entity == null)
            {
                return null;
            }

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, entity);
            return ms.ToArray();
        }

        public static T Deserialize(byte[] arrBytes)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            ms.Write(arrBytes, 0, arrBytes.Length);
            ms.Seek(0, SeekOrigin.Begin);
            T image = (T)bf.Deserialize(ms);
            return image;
        }
    }
}
