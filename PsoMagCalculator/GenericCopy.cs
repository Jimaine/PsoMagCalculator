using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PsoMagCalculator
{
  class GenericCopy<T>
  {
    /// <summary>
    /// copy any class by value, if the class is defined as Serializable.
    /// </summary>
    /// <param name="m_other">The serializable class you want to copy.</param>
    /// <returns></returns>
    public static T DeepCopy(T m_other)
    {
      using (MemoryStream ms = new MemoryStream())
      {
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(ms, m_other);
        ms.Position = 0;
        return (T)formatter.Deserialize(ms);
      }
    }
  }
}
