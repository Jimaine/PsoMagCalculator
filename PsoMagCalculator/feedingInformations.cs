using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsoMagCalculator
{
  class FeedingInformations
  {
    private int sync;
    private int iQ;
    private int def;
    private int pow;
    private int dex;
    private int mind;

    public int Sync
    {
      get
      {
        return this.sync;
      }
    }

    public int IQ
    {
      get
      {
        return this.iQ;
      }
    }

    public int Def
    {
      get
      {
        return this.def;
      }
    }

    public int Pow
    {
      get
      {
        return this.pow;
      }
    }

    public int Dex
    {
      get
      {
        return this.dex;
      }
    }

    public int Mind
    {
      get
      {
        return this.mind;
      }
    }

    public FeedingInformations()
    {
      sync = 0;
      iQ = 0;
      def = 0;
      pow = 0;
      dex = 0;
      mind = 0;
    }

    public void GetUpdatedMag()
    {

    }

    private static List<int> ffffff(Mag p_mag, Item p_item)
    {
      Mag dddd;
      List<int> values = new List<int>();
      //List<Mag> bikes = new List<Mag>();

      //bikes.add(new Mag {  Level });
      //bikes.add(new Mag { make = "Vroom", color = "red" });
      switch (p_item)
      {
        case Item.Monomate:
          dddd = new Mag { Sync = 3, IQ = 5, DefValue = 5, PowValue = 40, DexValue = 5, MindValue = 0 };
          p_mag.Sync += 3;
          p_mag.IQ += 3;
          p_mag.DefValue += 5;
          p_mag.PowValue += 40;
          p_mag.DexValue += 5;
          p_mag.MindValue += 0;
          break;
        case Item.Dimate:
          p_mag.Sync += 3;
          p_mag.IQ += 3;
          p_mag.DefValue += 10;
          p_mag.PowValue += 45;
          p_mag.DexValue += 5;
          p_mag.MindValue += 0;
          break;
        case Item.Trimate:
          p_mag.Sync += 4;
          p_mag.IQ += 4;
          p_mag.DefValue += 15;
          p_mag.PowValue += 50;
          p_mag.DexValue += 10;
          p_mag.MindValue += 0;
          break;
        case Item.Monofluid:
          p_mag.Sync += 3;
          p_mag.IQ += 3;
          p_mag.DefValue += 5;
          p_mag.PowValue += 0;
          p_mag.DexValue += 5;
          p_mag.MindValue += 40;
          break;
        case Item.Difluid:
          p_mag.Sync += 3;
          p_mag.IQ += 3;
          p_mag.DefValue += 10;
          p_mag.PowValue += 0;
          p_mag.DexValue += 5;
          p_mag.MindValue += 45;
          break;
        case Item.Trifluid:
          p_mag.Sync += 4;
          p_mag.IQ += 4;
          p_mag.DefValue += 15;
          p_mag.PowValue += 0;
          p_mag.DexValue += 10;
          p_mag.MindValue += 50;
          break;
        case Item.Antidote:
          p_mag.Sync += 3;
          p_mag.IQ += 3;
          p_mag.DefValue += 5;
          p_mag.PowValue += 1;
          p_mag.DexValue += 40;
          p_mag.MindValue += 0;
          break;
        case Item.Antiparalysis:
          p_mag.Sync += 3;
          p_mag.IQ += 3;
          p_mag.DefValue += 5;
          p_mag.PowValue += 0;
          p_mag.DexValue += 44;
          p_mag.MindValue += 10;
          break;
        case Item.SolAtomizer:
          p_mag.Sync += 4;
          p_mag.IQ += 1;
          p_mag.DefValue += 15;
          p_mag.PowValue += 30;
          p_mag.DexValue += 15;
          p_mag.MindValue += 25;
          break;
        case Item.MoonAtomizer:
          p_mag.Sync += 4;
          p_mag.IQ += 1;
          p_mag.DefValue += 15;
          p_mag.PowValue += 25;
          p_mag.DexValue += 15;
          p_mag.MindValue += 30;
          break;
        case Item.StarAtomizer:
          p_mag.Sync += 5;
          p_mag.IQ += 5;
          p_mag.DefValue += 25;
          p_mag.PowValue += 25;
          p_mag.DexValue += 25;
          p_mag.MindValue += 25;
          break;
        default:
          break;
      }

      return values;
    }

    private static void MagTableOne(Mag p_mag, Item p_item)
    {
      switch (p_item)
      {
        case Item.Monomate:
          p_mag.Sync += 3;
          p_mag.IQ += 3;
          p_mag.DefValue += 5;
          p_mag.PowValue += 40;
          p_mag.DexValue += 5;
          p_mag.MindValue += 0;
          break;
        case Item.Dimate:
          p_mag.Sync += 3;
          p_mag.IQ += 3;
          p_mag.DefValue += 10;
          p_mag.PowValue += 45;
          p_mag.DexValue += 5;
          p_mag.MindValue += 0;
          break;
        case Item.Trimate:
          p_mag.Sync += 4;
          p_mag.IQ += 4;
          p_mag.DefValue += 15;
          p_mag.PowValue += 50;
          p_mag.DexValue += 10;
          p_mag.MindValue += 0;
          break;
        case Item.Monofluid:
          p_mag.Sync += 3;
          p_mag.IQ += 3;
          p_mag.DefValue += 5;
          p_mag.PowValue += 0;
          p_mag.DexValue += 5;
          p_mag.MindValue += 40;
          break;
        case Item.Difluid:
          p_mag.Sync += 3;
          p_mag.IQ += 3;
          p_mag.DefValue += 10;
          p_mag.PowValue += 0;
          p_mag.DexValue += 5;
          p_mag.MindValue += 45;
          break;
        case Item.Trifluid:
          p_mag.Sync += 4;
          p_mag.IQ += 4;
          p_mag.DefValue += 15;
          p_mag.PowValue += 0;
          p_mag.DexValue += 10;
          p_mag.MindValue += 50;
          break;
        case Item.Antidote:
          p_mag.Sync += 3;
          p_mag.IQ += 3;
          p_mag.DefValue += 5;
          p_mag.PowValue += 1;
          p_mag.DexValue += 40;
          p_mag.MindValue += 0;
          break;
        case Item.Antiparalysis:
          p_mag.Sync += 3;
          p_mag.IQ += 3;
          p_mag.DefValue += 5;
          p_mag.PowValue += 0;
          p_mag.DexValue += 44;
          p_mag.MindValue += 10;
          break;
        case Item.SolAtomizer:
          p_mag.Sync += 4;
          p_mag.IQ += 1;
          p_mag.DefValue += 15;
          p_mag.PowValue += 30;
          p_mag.DexValue += 15;
          p_mag.MindValue += 25;
          break;
        case Item.MoonAtomizer:
          p_mag.Sync += 4;
          p_mag.IQ += 1;
          p_mag.DefValue += 15;
          p_mag.PowValue += 25;
          p_mag.DexValue += 15;
          p_mag.MindValue += 30;
          break;
        case Item.StarAtomizer:
          p_mag.Sync += 5;
          p_mag.IQ += 5;
          p_mag.DefValue += 25;
          p_mag.PowValue += 25;
          p_mag.DexValue += 25;
          p_mag.MindValue += 25;
          break;
        default:
          break;
      }
    }

    private static void MagTableTwo(Mag p_mag, Item p_item)
    {
      switch (p_item)
      {
        case Item.Monomate:
          p_mag.Sync += 0;
          p_mag.IQ += 0;
          p_mag.DefValue += 5;
          p_mag.PowValue += 10;
          p_mag.DexValue += 0;
          p_mag.MindValue += -1;
          break;
        case Item.Dimate:
          p_mag.Sync += 2;
          p_mag.IQ += 1;
          p_mag.DefValue += 6;
          p_mag.PowValue += 15;
          p_mag.DexValue += 3;
          p_mag.MindValue += -1;
          break;
        case Item.Trimate:
          p_mag.Sync += 3;
          p_mag.IQ += 2;
          p_mag.DefValue += 12;
          p_mag.PowValue += 21;
          p_mag.DexValue += 4;
          p_mag.MindValue += -7;
          break;
        case Item.Monofluid:
          p_mag.Sync += 0;
          p_mag.IQ += 0;
          p_mag.DefValue += 5;
          p_mag.PowValue += 0;
          p_mag.DexValue += 0;
          p_mag.MindValue += 8;
          break;
        case Item.Difluid:
          p_mag.Sync += 2;
          p_mag.IQ += 1;
          p_mag.DefValue += 7;
          p_mag.PowValue += 0;
          p_mag.DexValue += 3;
          p_mag.MindValue += 13;
          break;
        case Item.Trifluid:
          p_mag.Sync += 3;
          p_mag.IQ += 2;
          p_mag.DefValue += 7;
          p_mag.PowValue += -7;
          p_mag.DexValue += 6;
          p_mag.MindValue += 19;
          break;
        case Item.Antidote:
          p_mag.Sync += 0;
          p_mag.IQ += 1;
          p_mag.DefValue += 0;
          p_mag.PowValue += 5;
          p_mag.DexValue += 15;
          p_mag.MindValue += 0;
          break;
        case Item.Antiparalysis:
          p_mag.Sync += 2;
          p_mag.IQ += 0;
          p_mag.DefValue += -1;
          p_mag.PowValue += 0;
          p_mag.DexValue += 14;
          p_mag.MindValue += 5;
          break;
        case Item.SolAtomizer:
          p_mag.Sync += -2;
          p_mag.IQ += 2;
          p_mag.DefValue += 10;
          p_mag.PowValue += 11;
          p_mag.DexValue += 8;
          p_mag.MindValue += 0;
          break;
        case Item.MoonAtomizer:
          p_mag.Sync += 3;
          p_mag.IQ += -2;
          p_mag.DefValue += 9;
          p_mag.PowValue += 0;
          p_mag.DexValue += 9;
          p_mag.MindValue += 11;
          break;
        case Item.StarAtomizer:
          p_mag.Sync += 4;
          p_mag.IQ += 3;
          p_mag.DefValue += 14;
          p_mag.PowValue += 9;
          p_mag.DexValue += 18;
          p_mag.MindValue += 11;
          break;
        default:
          break;
      }
    }

    private static void MagTableThree(Mag p_mag, Item p_item)
    {
      switch (p_item)
      {
        case Item.Monomate:
          p_mag.Sync += 0;
          p_mag.IQ += -1;
          p_mag.DefValue += 1;
          p_mag.PowValue += 9;
          p_mag.DexValue += 0;
          p_mag.MindValue += -5;
          break;
        case Item.Dimate:
          p_mag.Sync += 3;
          p_mag.IQ += 0;
          p_mag.DefValue += 1;
          p_mag.PowValue += 13;
          p_mag.DexValue += 0;
          p_mag.MindValue += -10;
          break;
        case Item.Trimate:
          p_mag.Sync += 4;
          p_mag.IQ += 1;
          p_mag.DefValue += 8;
          p_mag.PowValue += 16;
          p_mag.DexValue += 2;
          p_mag.MindValue += -15;
          break;
        case Item.Monofluid:
          p_mag.Sync += 0;
          p_mag.IQ += -1;
          p_mag.DefValue += 0;
          p_mag.PowValue += -5;
          p_mag.DexValue += 0;
          p_mag.MindValue += 9;
          break;
        case Item.Difluid:
          p_mag.Sync += 3;
          p_mag.IQ += 0;
          p_mag.DefValue += 4;
          p_mag.PowValue += -10;
          p_mag.DexValue += 0;
          p_mag.MindValue += 13;
          break;
        case Item.Trifluid:
          p_mag.Sync += 3;
          p_mag.IQ += 2;
          p_mag.DefValue += 6;
          p_mag.PowValue += -15;
          p_mag.DexValue += 5;
          p_mag.MindValue += 17;
          break;
        case Item.Antidote:
          p_mag.Sync += -1;
          p_mag.IQ += 1;
          p_mag.DefValue += -5;
          p_mag.PowValue += 4;
          p_mag.DexValue += 12;
          p_mag.MindValue += -5;
          break;
        case Item.Antiparalysis:
          p_mag.Sync += 0;
          p_mag.IQ += 0;
          p_mag.DefValue += -5;
          p_mag.PowValue += -6;
          p_mag.DexValue += 11;
          p_mag.MindValue += 4;
          break;
        case Item.SolAtomizer:
          p_mag.Sync += 4;
          p_mag.IQ += -2;
          p_mag.DefValue += 0;
          p_mag.PowValue += 11;
          p_mag.DexValue += 3;
          p_mag.MindValue += -5;
          break;
        case Item.MoonAtomizer:
          p_mag.Sync += -1;
          p_mag.IQ += 1;
          p_mag.DefValue += 4;
          p_mag.PowValue += -5;
          p_mag.DexValue += 0;
          p_mag.MindValue += 11;
          break;
        case Item.StarAtomizer:
          p_mag.Sync += 4;
          p_mag.IQ += 2;
          p_mag.DefValue += 7;
          p_mag.PowValue += 8;
          p_mag.DexValue += 6;
          p_mag.MindValue += 9;
          break;
        default:
          break;
      }
    }

    private static void MagTableFour(Mag p_mag, Item p_item)
    {
      switch (p_item)
      {
        case Item.Monomate:
          p_mag.Sync += 0;
          p_mag.IQ += -1;
          p_mag.DefValue += 0;
          p_mag.PowValue += 3;
          p_mag.DexValue += 0;
          p_mag.MindValue += 0;
          break;
        case Item.Dimate:
          p_mag.Sync += 2;
          p_mag.IQ += 0;
          p_mag.DefValue += 5;
          p_mag.PowValue += 7;
          p_mag.DexValue += 0;
          p_mag.MindValue += -5;
          break;
        case Item.Trimate:
          p_mag.Sync += 3;
          p_mag.IQ += 1;
          p_mag.DefValue += 4;
          p_mag.PowValue += 14;
          p_mag.DexValue += -6;
          p_mag.MindValue += -10;
          break;
        case Item.Monofluid:
          p_mag.Sync += 0;
          p_mag.IQ += 0;
          p_mag.DefValue += 0;
          p_mag.PowValue += 0;
          p_mag.DexValue += 0;
          p_mag.MindValue += 4;
          break;
        case Item.Difluid:
          p_mag.Sync += 0;
          p_mag.IQ += 1;
          p_mag.DefValue += 4;
          p_mag.PowValue += -5;
          p_mag.DexValue += 0;
          p_mag.MindValue += 8;
          break;
        case Item.Trifluid:
          p_mag.Sync += 2;
          p_mag.IQ += 2;
          p_mag.DefValue += 4;
          p_mag.PowValue += -10;
          p_mag.DexValue += 3;
          p_mag.MindValue += 15;
          break;
        case Item.Antidote:
          p_mag.Sync += -3;
          p_mag.IQ += 3;
          p_mag.DefValue += 0;
          p_mag.PowValue += 0;
          p_mag.DexValue += 7;
          p_mag.MindValue += 0;
          break;
        case Item.Antiparalysis:
          p_mag.Sync += 3;
          p_mag.IQ += 0;
          p_mag.DefValue += -4;
          p_mag.PowValue += -5;
          p_mag.DexValue += 20;
          p_mag.MindValue += -5;
          break;
        case Item.SolAtomizer:
          p_mag.Sync += 3;
          p_mag.IQ += -2;
          p_mag.DefValue += -10;
          p_mag.PowValue += 9;
          p_mag.DexValue += 6;
          p_mag.MindValue += 9;
          break;
        case Item.MoonAtomizer:
          p_mag.Sync += -2;
          p_mag.IQ += 2;
          p_mag.DefValue += 8;
          p_mag.PowValue += 5;
          p_mag.DexValue += -8;
          p_mag.MindValue += 7;
          break;
        case Item.StarAtomizer:
          p_mag.Sync += 3;
          p_mag.IQ += 2;
          p_mag.DefValue += 7;
          p_mag.PowValue += 7;
          p_mag.DexValue += 7;
          p_mag.MindValue += 7;
          break;
        default:
          break;
      }
    }

    private static void MagTableFive(Mag p_mag, Item p_item)
    {
      switch (p_item)
      {
        case Item.Monomate:
          p_mag.Sync += 2;
          p_mag.IQ += -1;
          p_mag.DefValue += -5;
          p_mag.PowValue += 9;
          p_mag.DexValue += -5;
          p_mag.MindValue += 0;
          break;
        case Item.Dimate:
          p_mag.Sync += 2;
          p_mag.IQ += 0;
          p_mag.DefValue += 0;
          p_mag.PowValue += 11;
          p_mag.DexValue += 0;
          p_mag.MindValue += -10;
          break;
        case Item.Trimate:
          p_mag.Sync += 0;
          p_mag.IQ += 1;
          p_mag.DefValue += 4;
          p_mag.PowValue += 14;
          p_mag.DexValue += 0;
          p_mag.MindValue += -15;
          break;
        case Item.Monofluid:
          p_mag.Sync += 2;
          p_mag.IQ += -1;
          p_mag.DefValue += -5;
          p_mag.PowValue += 0;
          p_mag.DexValue += -6;
          p_mag.MindValue += 18;
          break;
        case Item.Difluid:
          p_mag.Sync += 2;
          p_mag.IQ += 0;
          p_mag.DefValue += 0;
          p_mag.PowValue += -10;
          p_mag.DexValue += 0;
          p_mag.MindValue += 11;
          break;
        case Item.Trifluid:
          p_mag.Sync += 0;
          p_mag.IQ += 1;
          p_mag.DefValue += 4;
          p_mag.PowValue += -15;
          p_mag.DexValue += 0;
          p_mag.MindValue += 15;
          break;
        case Item.Antidote:
          p_mag.Sync += 2;
          p_mag.IQ += -1;
          p_mag.DefValue += -5;
          p_mag.PowValue += -5;
          p_mag.DexValue += 16;
          p_mag.MindValue += -5;
          break;
        case Item.Antiparalysis:
          p_mag.Sync += -2;
          p_mag.IQ += 3;
          p_mag.DefValue += 7;
          p_mag.PowValue += -3;
          p_mag.DexValue += 0;
          p_mag.MindValue += -3;
          break;
        case Item.SolAtomizer:
          p_mag.Sync += 4;
          p_mag.IQ += -2;
          p_mag.DefValue += 5;
          p_mag.PowValue += 21;
          p_mag.DexValue += -5;
          p_mag.MindValue += 20;
          break;
        case Item.MoonAtomizer:
          p_mag.Sync += 3;
          p_mag.IQ += 0;
          p_mag.DefValue += -5;
          p_mag.PowValue += -20;
          p_mag.DexValue += 5;
          p_mag.MindValue += 21;
          break;
        case Item.StarAtomizer:
          p_mag.Sync += 3;
          p_mag.IQ += -2;
          p_mag.DefValue += 4;
          p_mag.PowValue += 6;
          p_mag.DexValue += 8;
          p_mag.MindValue += 5;
          break;
        default:
          break;
      }
    }

    private static void MagTableSix(Mag p_mag, Item p_item)
    {
      switch (p_item)
      {
        case Item.Monomate:
          p_mag.Sync += 2;
          p_mag.IQ += -1;
          p_mag.DefValue += -4;
          p_mag.PowValue += 13;
          p_mag.DexValue += -5;
          p_mag.MindValue += -5;
          break;
        case Item.Dimate:
          p_mag.Sync += 0;
          p_mag.IQ += 1;
          p_mag.DefValue += 0;
          p_mag.PowValue += 16;
          p_mag.DexValue += 0;
          p_mag.MindValue += -15;
          break;
        case Item.Trimate:
          p_mag.Sync += 2;
          p_mag.IQ += 0;
          p_mag.DefValue += 3;
          p_mag.PowValue += 19;
          p_mag.DexValue += -2;
          p_mag.MindValue += -18;
          break;
        case Item.Monofluid:
          p_mag.Sync += 2;
          p_mag.IQ += -1;
          p_mag.DefValue += -4;
          p_mag.PowValue += -5;
          p_mag.DexValue += -5;
          p_mag.MindValue += 13;
          break;
        case Item.Difluid:
          p_mag.Sync += 0;
          p_mag.IQ += 1;
          p_mag.DefValue += 0;
          p_mag.PowValue += -15;
          p_mag.DexValue += 0;
          p_mag.MindValue += 16;
          break;
        case Item.Trifluid:
          p_mag.Sync += 2;
          p_mag.IQ += 0;
          p_mag.DefValue += 3;
          p_mag.PowValue += -20;
          p_mag.DexValue += 0;
          p_mag.MindValue += 19;
          break;
        case Item.Antidote:
          p_mag.Sync += 0;
          p_mag.IQ += 1;
          p_mag.DefValue += 5;
          p_mag.PowValue += -6;
          p_mag.DexValue += 6;
          p_mag.MindValue += -5;
          break;
        case Item.Antiparalysis:
          p_mag.Sync += -1;
          p_mag.IQ += 1;
          p_mag.DefValue += 0;
          p_mag.PowValue += -4;
          p_mag.DexValue += 14;
          p_mag.MindValue += -10;
          break;
        case Item.SolAtomizer:
          p_mag.Sync += 4;
          p_mag.IQ += -1;
          p_mag.DefValue += 4;
          p_mag.PowValue += 17;
          p_mag.DexValue += -5;
          p_mag.MindValue += -15;
          break;
        case Item.MoonAtomizer:
          p_mag.Sync += 2;
          p_mag.IQ += 0;
          p_mag.DefValue += -10;
          p_mag.PowValue += -15;
          p_mag.DexValue += 5;
          p_mag.MindValue += 21;
          break;
        case Item.StarAtomizer:
          p_mag.Sync += 3;
          p_mag.IQ += 2;
          p_mag.DefValue += 2;
          p_mag.PowValue += 8;
          p_mag.DexValue += 3;
          p_mag.MindValue += 6;
          break;
        default:
          break;
      }
    }

    private static void MagTableSeven(Mag p_mag, Item p_item)
    {
      switch (p_item)
      {
        case Item.Monomate:
          p_mag.Sync += -1;
          p_mag.IQ += 1;
          p_mag.DefValue += -3;
          p_mag.PowValue += 9;
          p_mag.DexValue += -3;
          p_mag.MindValue += -4;
          break;
        case Item.Dimate:
          p_mag.Sync += 2;
          p_mag.IQ += 0;
          p_mag.DefValue += 0;
          p_mag.PowValue += 11;
          p_mag.DexValue += 0;
          p_mag.MindValue += -10;
          break;
        case Item.Trimate:
          p_mag.Sync += 2;
          p_mag.IQ += 0;
          p_mag.DefValue += 2;
          p_mag.PowValue += 15;
          p_mag.DexValue += 0;
          p_mag.MindValue += -16;
          break;
        case Item.Monofluid:
          p_mag.Sync += -1;
          p_mag.IQ += 3;
          p_mag.DefValue += -3;
          p_mag.PowValue += -4;
          p_mag.DexValue += -3;
          p_mag.MindValue += 9;
          break;
        case Item.Difluid:
          p_mag.Sync += 2;
          p_mag.IQ += 0;
          p_mag.DefValue += 0;
          p_mag.PowValue += -10;
          p_mag.DexValue += 0;
          p_mag.MindValue += 11;
          break;
        case Item.Trifluid:
          p_mag.Sync += 2;
          p_mag.IQ += 0;
          p_mag.DefValue += -2;
          p_mag.PowValue += -15;
          p_mag.DexValue += 0;
          p_mag.MindValue += 19;
          break;
        case Item.Antidote:
          p_mag.Sync += 2;
          p_mag.IQ += -1;
          p_mag.DefValue += 0;
          p_mag.PowValue += 6;
          p_mag.DexValue += 9;
          p_mag.MindValue += -15;
          break;
        case Item.Antiparalysis:
          p_mag.Sync += -2;
          p_mag.IQ += 3;
          p_mag.DefValue += 0;
          p_mag.PowValue += -15;
          p_mag.DexValue += 9;
          p_mag.MindValue += 6;
          break;
        case Item.SolAtomizer:
          p_mag.Sync += 3;
          p_mag.IQ += -1;
          p_mag.DefValue += 9;
          p_mag.PowValue += -20;
          p_mag.DexValue += -5;
          p_mag.MindValue += 17;
          break;
        case Item.MoonAtomizer:
          p_mag.Sync += 0;
          p_mag.IQ += 2;
          p_mag.DefValue += -5;
          p_mag.PowValue += 20;
          p_mag.DexValue += 5;
          p_mag.MindValue += -20;
          break;
        case Item.StarAtomizer:
          p_mag.Sync += 3;
          p_mag.IQ += 2;
          p_mag.DefValue += 0;
          p_mag.PowValue += 11;
          p_mag.DexValue += 0;
          p_mag.MindValue += 11;
          break;
        default:
          break;
      }
    }

    private static void MagTableEight(Mag p_mag, Item p_item)
    {
      switch (p_item)
      {
        case Item.Monomate:
          p_mag.Sync += -1;
          p_mag.IQ += 0;
          p_mag.DefValue += -4;
          p_mag.PowValue += +21;
          p_mag.DexValue += -15;
          p_mag.MindValue += -5;
          break;
        case Item.Dimate:
          p_mag.Sync += 0;
          p_mag.IQ += 1;
          p_mag.DefValue += -1;
          p_mag.PowValue += 27;
          p_mag.DexValue += -10;
          p_mag.MindValue += -16;
          break;
        case Item.Trimate:
          p_mag.Sync += 2;
          p_mag.IQ += 0;
          p_mag.DefValue += 5;
          p_mag.PowValue += 29;
          p_mag.DexValue += -7;
          p_mag.MindValue += -25;
          break;
        case Item.Monofluid:
          p_mag.Sync += -1;
          p_mag.IQ += 0;
          p_mag.DefValue += -10;
          p_mag.PowValue += -5;
          p_mag.DexValue += -10;
          p_mag.MindValue += 21;
          break;
        case Item.Difluid:
          p_mag.Sync += 0;
          p_mag.IQ += 1;
          p_mag.DefValue += -5;
          p_mag.PowValue += -16;
          p_mag.DexValue += -5;
          p_mag.MindValue += 25;
          break;
        case Item.Trifluid:
          p_mag.Sync += 2;
          p_mag.IQ += 0;
          p_mag.DefValue += -7;
          p_mag.PowValue += -25;
          p_mag.DexValue += 6;
          p_mag.MindValue += 29;
          break;
        case Item.Antidote:
          p_mag.Sync += -1;
          p_mag.IQ += 1;
          p_mag.DefValue += -10;
          p_mag.PowValue += -10;
          p_mag.DexValue += 28;
          p_mag.MindValue += -10;
          break;
        case Item.Antiparalysis:
          p_mag.Sync += 2;
          p_mag.IQ += -1;
          p_mag.DefValue += 9;
          p_mag.PowValue += -18;
          p_mag.DexValue += 24;
          p_mag.MindValue += -15;
          break;
        case Item.SolAtomizer:
          p_mag.Sync += 2;
          p_mag.IQ += 1;
          p_mag.DefValue += 19;
          p_mag.PowValue += 18;
          p_mag.DexValue += -15;
          p_mag.MindValue += -20;
          break;
        case Item.MoonAtomizer:
          p_mag.Sync += 2;
          p_mag.IQ += 1;
          p_mag.DefValue += -15;
          p_mag.PowValue += -20;
          p_mag.DexValue += 19;
          p_mag.MindValue += 18;
          break;
        case Item.StarAtomizer:
          p_mag.Sync += 4;
          p_mag.IQ += 2;
          p_mag.DefValue += 3;
          p_mag.PowValue += 7;
          p_mag.DexValue += 3;
          p_mag.MindValue += 3;
          break;
        default:
          break;
      }
    }
  }
}
