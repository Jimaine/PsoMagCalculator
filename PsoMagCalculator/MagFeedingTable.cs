using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsoMagCalculator
{
  class MagFeedingTable
  {
    private List<Dictionary<Item, FeedingResults>> feedingTables = new List<Dictionary<Item, FeedingResults>>();

    /// <summary>
    /// Get a List of all eight FeedingTables.
    /// </summary>
    public List<Dictionary<Item, FeedingResults>> FeedingTables
    {
      get
      {
        return this.feedingTables;
      }
    }

    public MagFeedingTable()
    {
      Dictionary<Item, FeedingResults> feedingResults = new Dictionary<Item, FeedingResults>();
      feedingResults.Add(Item.Monomate, new FeedingResults(3, 3, 5, 40, 5, 0));
      feedingResults.Add(Item.Dimate, new FeedingResults(3, 3, 10, 45, 5, 0));
      feedingResults.Add(Item.Trimate, new FeedingResults(4, 4, 15, 50, 10, 0));
      feedingResults.Add(Item.Monofluid, new FeedingResults(3, 3, 5, 0, 5, 40));
      feedingResults.Add(Item.Difluid, new FeedingResults(3, 3, 10, 0, 5, 45));
      feedingResults.Add(Item.Trifluid, new FeedingResults(4, 4, 15, 0, 10, 50));
      feedingResults.Add(Item.Antidote, new FeedingResults(3, 3, 5, 1, 40, 0));
      feedingResults.Add(Item.Antiparalysis, new FeedingResults(3, 3, 5, 0, 44, 10));
      feedingResults.Add(Item.SolAtomizer, new FeedingResults(4, 1, 15, 30, 15, 25));
      feedingResults.Add(Item.MoonAtomizer, new FeedingResults(4, 1, 15, 25, 15, 30));
      feedingResults.Add(Item.StarAtomizer, new FeedingResults(5, 5, 25, 25, 25, 25));
      feedingTables.Add(feedingResults);

      feedingResults = new Dictionary<Item, FeedingResults>();
      feedingResults.Add(Item.Monomate, new FeedingResults(0, 0, 5, 10, 0, -1));
      feedingResults.Add(Item.Dimate, new FeedingResults(2, 1, 6, 15, 3, -1));
      feedingResults.Add(Item.Trimate, new FeedingResults(3, 2, 12, 21, 4, -7));
      feedingResults.Add(Item.Monofluid, new FeedingResults(0, 0, 5, 0, 0, 8));
      feedingResults.Add(Item.Difluid, new FeedingResults(2, 1, 7, 0, 3, 13));
      feedingResults.Add(Item.Trifluid, new FeedingResults(3, 2, 7, -7, 6, 19));
      feedingResults.Add(Item.Antidote, new FeedingResults(0, 1, 0, 5, 15, 0));
      feedingResults.Add(Item.Antiparalysis, new FeedingResults(2, 0, -1, 0, 14, 5));
      feedingResults.Add(Item.SolAtomizer, new FeedingResults(-2, 2, 10, 11, 8, 0));
      feedingResults.Add(Item.MoonAtomizer, new FeedingResults(3, -2, 9, 0, 9, 11));
      feedingResults.Add(Item.StarAtomizer, new FeedingResults(4, 3, 14, 9, 18, 11));
      feedingTables.Add(feedingResults);
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
