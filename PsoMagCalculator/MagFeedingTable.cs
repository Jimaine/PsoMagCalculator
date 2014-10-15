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
    /// Get the List of all eight FeedingTables.
    /// </summary>
    public List<Dictionary<Item, FeedingResults>> FeedingTables
    {
      get
      {
        return this.feedingTables;
      }
    }

    /// <summary>
    /// Basic Constructor to fill the List.
    /// </summary>
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

      feedingResults = new Dictionary<Item, FeedingResults>();
      feedingResults.Add(Item.Monomate, new FeedingResults(0, -1, 1, 9, 0, -5));
      feedingResults.Add(Item.Dimate, new FeedingResults(3, 0, 1, 13, 0, -10));
      feedingResults.Add(Item.Trimate, new FeedingResults(4, 1, 8, 16, 2, -15));
      feedingResults.Add(Item.Monofluid, new FeedingResults(0, -1, 0, -5, 0, 9));
      feedingResults.Add(Item.Difluid, new FeedingResults(3, 0, 4, -10, 0, 13));
      feedingResults.Add(Item.Trifluid, new FeedingResults(3, 2, 6, -15, 5, 17));
      feedingResults.Add(Item.Antidote, new FeedingResults(-1, 1, -5, 4, 12, -5));
      feedingResults.Add(Item.Antiparalysis, new FeedingResults(0, 0, -5, -6, 11, 4));
      feedingResults.Add(Item.SolAtomizer, new FeedingResults(4, -2, 0, 11, 3, -5));
      feedingResults.Add(Item.MoonAtomizer, new FeedingResults(-1, 1, 4, -5, 0, 11));
      feedingResults.Add(Item.StarAtomizer, new FeedingResults(4, 2, 7, 8, 6, 9));
      feedingTables.Add(feedingResults);

      feedingResults = new Dictionary<Item, FeedingResults>();
      feedingResults.Add(Item.Monomate, new FeedingResults(0, -1, 0, 3, 0, 0));
      feedingResults.Add(Item.Dimate, new FeedingResults(2, 0, 5, 7, 0, -5));
      feedingResults.Add(Item.Trimate, new FeedingResults(3, 1, 4, 14, -6, -10));
      feedingResults.Add(Item.Monofluid, new FeedingResults(0, 0, 0, 0, 0, 4));
      feedingResults.Add(Item.Difluid, new FeedingResults(0, 1, 4, -5, 0, 8));
      feedingResults.Add(Item.Trifluid, new FeedingResults(2, 2, 4, -10, 3, 15));
      feedingResults.Add(Item.Antidote, new FeedingResults(-3, 3, 0, 0, 7, 0));
      feedingResults.Add(Item.Antiparalysis, new FeedingResults(3, 0, -4, -5, 20, -5));
      feedingResults.Add(Item.SolAtomizer, new FeedingResults(3, -2, -10, 9, 6, 9));
      feedingResults.Add(Item.MoonAtomizer, new FeedingResults(-2, 2, 8, 5, -8, 7));
      feedingResults.Add(Item.StarAtomizer, new FeedingResults(3, 2, 7, 7, 7, 7));
      feedingTables.Add(feedingResults);

      feedingResults = new Dictionary<Item, FeedingResults>();
      feedingResults.Add(Item.Monomate, new FeedingResults(2, -1, -5, 9, -5, 0));
      feedingResults.Add(Item.Dimate, new FeedingResults(2, 0, 0, 11, 0, -10));
      feedingResults.Add(Item.Trimate, new FeedingResults(0, 1, 4, 14, 0, -15));
      feedingResults.Add(Item.Monofluid, new FeedingResults(2, -1, -5, 0, -6, 18));
      feedingResults.Add(Item.Difluid, new FeedingResults(2, 0, 0, -10, 0, 11));
      feedingResults.Add(Item.Trifluid, new FeedingResults(0, 1, 4, -15, 0, 15));
      feedingResults.Add(Item.Antidote, new FeedingResults(2, -1, -5, -5, 16, -5));
      feedingResults.Add(Item.Antiparalysis, new FeedingResults(-2, 3, 7, -3, 0, -3));
      feedingResults.Add(Item.SolAtomizer, new FeedingResults(4, -2, 5, 21, -5, 20));
      feedingResults.Add(Item.MoonAtomizer, new FeedingResults(3, 0, -5, -20, 5, 21));
      feedingResults.Add(Item.StarAtomizer, new FeedingResults(3, -2, 4, 6, 8, 5));
      feedingTables.Add(feedingResults);

      feedingResults = new Dictionary<Item, FeedingResults>();
      feedingResults.Add(Item.Monomate, new FeedingResults(2, -1, -4, 13, -5, -5));
      feedingResults.Add(Item.Dimate, new FeedingResults(0, 1, 0, 16, 0, -15));
      feedingResults.Add(Item.Trimate, new FeedingResults(2, 0, 3, 19, -2, -18));
      feedingResults.Add(Item.Monofluid, new FeedingResults(2, -1, -4, -5, -5, 13));
      feedingResults.Add(Item.Difluid, new FeedingResults(0, 1, 0, -15, 0, 16));
      feedingResults.Add(Item.Trifluid, new FeedingResults(2, 0, 3, -20, 0, 19));
      feedingResults.Add(Item.Antidote, new FeedingResults(0, 1, 5, -6, 6, -5));
      feedingResults.Add(Item.Antiparalysis, new FeedingResults(-1, 1, 0, -4, 14, -10));
      feedingResults.Add(Item.SolAtomizer, new FeedingResults(4, -1, 4, 17, -5, -15));
      feedingResults.Add(Item.MoonAtomizer, new FeedingResults(2, 0, -10, -15, 5, 21));
      feedingResults.Add(Item.StarAtomizer, new FeedingResults(3, 2, 2, 8, 3, 6));
      feedingTables.Add(feedingResults);

      feedingResults = new Dictionary<Item, FeedingResults>();
      feedingResults.Add(Item.Monomate, new FeedingResults(-1, 1, -3, 9, -3, -4));
      feedingResults.Add(Item.Dimate, new FeedingResults(2, 0, 0, 11, 0, -10));
      feedingResults.Add(Item.Trimate, new FeedingResults(2, 0, 2, 15, 0, -16));
      feedingResults.Add(Item.Monofluid, new FeedingResults(-1, 3, -3, -4, -3, 9));
      feedingResults.Add(Item.Difluid, new FeedingResults(2, 0, 0, -10, 0, 11));
      feedingResults.Add(Item.Trifluid, new FeedingResults(2, 0, -2, -15, 0, 19));
      feedingResults.Add(Item.Antidote, new FeedingResults(2, -1, 0, 6, 9, -15));
      feedingResults.Add(Item.Antiparalysis, new FeedingResults(-2, 3, 0, -15, 9, 6));
      feedingResults.Add(Item.SolAtomizer, new FeedingResults(3, -1, 9, -20, -5, 17));
      feedingResults.Add(Item.MoonAtomizer, new FeedingResults(0, 2, -5, 20, 5, -20));
      feedingResults.Add(Item.StarAtomizer, new FeedingResults(3, 2, 0, 11, 0, 11));
      feedingTables.Add(feedingResults);

      feedingResults = new Dictionary<Item, FeedingResults>();
      feedingResults.Add(Item.Monomate, new FeedingResults(-1, 0, -4, 21, -15, -5));
      feedingResults.Add(Item.Dimate, new FeedingResults(0, 1, -1, 27, -10, -16));
      feedingResults.Add(Item.Trimate, new FeedingResults(2, 0, 5, 29, -7, -25));
      feedingResults.Add(Item.Monofluid, new FeedingResults(-1, 0, -10, -5, -10, 21));
      feedingResults.Add(Item.Difluid, new FeedingResults(0, 1, -5, -16, -5, 25));
      feedingResults.Add(Item.Trifluid, new FeedingResults(2, 0, -7, -25, 6, 29));
      feedingResults.Add(Item.Antidote, new FeedingResults(-1, 1, -10, -10, 28, -10));
      feedingResults.Add(Item.Antiparalysis, new FeedingResults(2, -1, 9, -18, 24, -15));
      feedingResults.Add(Item.SolAtomizer, new FeedingResults(2, 1, 19, 18, -15, -20));
      feedingResults.Add(Item.MoonAtomizer, new FeedingResults(2, 1, -15, -20, 19, 18));
      feedingResults.Add(Item.StarAtomizer, new FeedingResults(4, 2, 3, 7, 3, 3));
      feedingTables.Add(feedingResults);
    }
  }
}
