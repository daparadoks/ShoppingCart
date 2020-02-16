using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ShoppingCart.Api.Extensions
{
    public static class SerializerExtension
    {
        public static byte[] Serialize(this object obj)
        {
            if (obj == null) return null;

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }

        public static T Deserialize<T>(this byte[] byteArray)
        {
            if (byteArray == null) return default;

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream(byteArray))
            {
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}