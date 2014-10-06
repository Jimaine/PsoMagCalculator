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
