using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsoMagCalculator
{
  [Serializable]
  class Mag
  {
    private MagName name;
    private List<PhotonBlast> photonBlasts;
    private int level;
    private int sync;
    private int iQ;
    private int defValue;
    private int powValue;
    private int dexValue;
    private int mindValue;
    private int defLevel;
    private int powLevel;
    private int dexLevel;
    private int mindLevel;
    private int meseta;

    public List<PhotonBlast> PhotonBlasts
    {
      get
      {
        return this.photonBlasts;
      }
      set
      {
        photonBlasts = value;
      }
    }

    public MagName Name
    {
      get
      {
        return this.name;
      }
      set
      {
        name = value;
      }
    }

    public int Level
    {
      get
      {
        return this.level;
      }
      set
      {
        level = value;
      }
    }

    public int Sync
    {
      get
      {
        return this.sync;
      }
      set
      {
        sync = value;
      }
    }

    public int IQ
    {
      get
      {
        return this.iQ;
      }
      set
      {
        iQ = value;
      }
    }

    public int DefValue
    {
      get
      {
        return this.defValue;
      }
      set
      {
        defValue = value;
      }
    }

    public int PowValue
    {
      get
      {
        return this.powValue;
      }
      set
      {
        powValue = value;
      }
    }

    public int DexValue
    {
      get
      {
        return this.dexValue;
      }
      set
      {
        dexValue = value;
      }
    }

    public int MindValue
    {
      get
      {
        return this.mindValue;
      }
      set
      {
        mindValue = value;
      }
    }

    public int DefLevel
    {
      get
      {
        return this.defLevel;
      }
      set
      {
        defLevel = value;
      }
    }

    public int PowLevel
    {
      get
      {
        return this.powLevel;
      }
      set
      {
        powLevel = value;
      }
    }

    public int DexLevel
    {
      get
      {
        return this.dexLevel;
      }
      set
      {
        dexLevel = value;
      }
    }

    public int MindLevel
    {
      get
      {
        return this.mindLevel;
      }
      set
      {
        mindLevel = value;
      }
    }

    public int Meseta
    {
      get
      {
        return this.meseta;
      }
      set
      {
        meseta = value;
      }
    }

    public Mag()
    {
      this.name = MagName.Mag;
      this.photonBlasts = new List<PhotonBlast>();
      this.level = 5;
      this.sync = 0;
      this.iQ = 0;
      this.defValue = 0;
      this.powValue = 0;
      this.dexValue = 0;
      this.mindValue = 0;
      this.defLevel = 5;
      this.powLevel = 0;
      this.dexLevel = 0;
      this.mindLevel = 0;
      this.meseta = 0;
    }
  }

  enum MagName
  {
    Mag,
    Varuna,
    Vritra,
    Kalki,
    Ashvinau,
    Sumba,
    Namuci,
    Marutah,
    Rudra,
    Surya,
    Tapas,
    Mitra,
    Asperus,
    Vayu,
    Varaha,
    Ushasu,
    Kama,
    Kaitabha,
    Kumara,
    Bhirava,
    Ila,
    Garuda,
    Sita,
    Soma,
    Durga,
    Nandin,
    Yaksa,
    Ribhava,
    Andhaka,
    Kabanda,
    Naga,
    Naraka,
    Bana,
    Marica,
    Madhu,
    Ravana,
    Deva,
    Rati,
    Savitri,
    Rukmin,
    Pushan,
    Diwari,
    Nidra,
    Sato,
    Bhima
  }
}
