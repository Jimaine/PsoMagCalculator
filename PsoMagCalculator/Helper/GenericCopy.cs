using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PsoMagCalculator
{
    class GenericCopy<T>
    {
        public static T DeepCopy(T serializableClass)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(memoryStream, serializableClass);
                memoryStream.Position = 0;

                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
