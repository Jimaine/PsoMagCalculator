using System;
using System.Collections.Generic;

namespace PsoMagCalculator
{
    class MagFeedingTable
    {
        public List<Dictionary<Item, FeedingResults>> FeedingTables { get; } = new List<Dictionary<Item, FeedingResults>>()
        {
            {
                new Dictionary<Item, FeedingResults> {
                    { Item.Monomate, new FeedingResults(3, 3, 5, 40, 5, 0) },
                    { Item.Dimate, new FeedingResults(3, 3, 10, 45, 5, 0) },
                    { Item.Trimate, new FeedingResults(4, 4, 15, 50, 10, 0) },
                    { Item.Monofluid, new FeedingResults(3, 3, 5, 0, 5, 40) },
                    { Item.Difluid, new FeedingResults(3, 3, 10, 0, 5, 45) },
                    { Item.Trifluid, new FeedingResults(4, 4, 15, 0, 10, 50) },
                    { Item.Antidote, new FeedingResults(3, 3, 5, 1, 40, 0) },
                    { Item.Antiparalysis, new FeedingResults(3, 3, 5, 0, 44, 10) },
                    { Item.SolAtomizer, new FeedingResults(4, 1, 15, 30, 15, 25) },
                    { Item.MoonAtomizer, new FeedingResults(4, 1, 15, 25, 15, 30) },
                    { Item.StarAtomizer, new FeedingResults(5, 5, 25, 25, 25, 25) }
                }
            },
            {
                new Dictionary<Item, FeedingResults> {
                    { Item.Monomate, new FeedingResults(0, 0, 5, 10, 0, -1) },
                    { Item.Dimate, new FeedingResults(2, 1, 6, 15, 3, -1) },
                    { Item.Trimate, new FeedingResults(3, 2, 12, 21, 4, -7) },
                    { Item.Monofluid, new FeedingResults(0, 0, 5, 0, 0, 8) },
                    { Item.Difluid, new FeedingResults(2, 1, 7, 0, 3, 13) },
                    { Item.Trifluid, new FeedingResults(3, 2, 7, -7, 6, 19) },
                    { Item.Antidote, new FeedingResults(0, 1, 0, 5, 15, 0) },
                    { Item.Antiparalysis, new FeedingResults(2, 0, -1, 0, 14, 5) },
                    { Item.SolAtomizer, new FeedingResults(-2, 2, 10, 11, 8, 0) },
                    { Item.MoonAtomizer, new FeedingResults(3, -2, 9, 0, 9, 11) },
                    { Item.StarAtomizer, new FeedingResults(4, 3, 14, 9, 18, 11) }
                }
            },
            {
                new Dictionary<Item, FeedingResults> {
                    { Item.Monomate, new FeedingResults(0, -1, 1, 9, 0, -5) },
                    { Item.Dimate, new FeedingResults(3, 0, 1, 13, 0, -10) },
                    { Item.Trimate, new FeedingResults(4, 1, 8, 16, 2, -15) },
                    { Item.Monofluid, new FeedingResults(0, -1, 0, -5, 0, 9) },
                    { Item.Difluid, new FeedingResults(3, 0, 4, -10, 0, 13) },
                    { Item.Trifluid, new FeedingResults(3, 2, 6, -15, 5, 17) },
                    { Item.Antidote, new FeedingResults(-1, 1, -5, 4, 12, -5) },
                    { Item.Antiparalysis, new FeedingResults(0, 0, -5, -6, 11, 4) },
                    { Item.SolAtomizer, new FeedingResults(4, -2, 0, 11, 3, -5) },
                    { Item.MoonAtomizer, new FeedingResults(-1, 1, 4, -5, 0, 11) },
                    { Item.StarAtomizer, new FeedingResults(4, 2, 7, 8, 6, 9) }
                }
            },
            {
                new Dictionary<Item, FeedingResults> {
                    { Item.Monomate, new FeedingResults(0, -1, 0, 3, 0, 0) },
                    { Item.Dimate, new FeedingResults(2, 0, 5, 7, 0, -5) },
                    { Item.Trimate, new FeedingResults(3, 1, 4, 14, -6, -10) },
                    { Item.Monofluid, new FeedingResults(0, 0, 0, 0, 0, 4) },
                    { Item.Difluid, new FeedingResults(0, 1, 4, -5, 0, 8) },
                    { Item.Trifluid, new FeedingResults(2, 2, 4, -10, 3, 15) },
                    { Item.Antidote, new FeedingResults(-3, 3, 0, 0, 7, 0) },
                    { Item.Antiparalysis, new FeedingResults(3, 0, -4, -5, 20, -5) },
                    { Item.SolAtomizer, new FeedingResults(3, -2, -10, 9, 6, 9) },
                    { Item.MoonAtomizer, new FeedingResults(-2, 2, 8, 5, -8, 7) },
                    { Item.StarAtomizer, new FeedingResults(3, 2, 7, 7, 7, 7) }
                }
            },
            {
                new Dictionary<Item, FeedingResults> {
                    { Item.Monomate, new FeedingResults(2, -1, -5, 9, -5, 0) },
                    { Item.Dimate, new FeedingResults(2, 0, 0, 11, 0, -10) },
                    { Item.Trimate, new FeedingResults(0, 1, 4, 14, 0, -15) },
                    { Item.Monofluid, new FeedingResults(2, -1, -5, 0, -6, 18) },
                    { Item.Difluid, new FeedingResults(2, 0, 0, -10, 0, 11) },
                    { Item.Trifluid, new FeedingResults(0, 1, 4, -15, 0, 15) },
                    { Item.Antidote, new FeedingResults(2, -1, -5, -5, 16, -5) },
                    { Item.Antiparalysis, new FeedingResults(-2, 3, 7, -3, 0, -3) },
                    { Item.SolAtomizer, new FeedingResults(4, -2, 5, 21, -5, 20) },
                    { Item.MoonAtomizer, new FeedingResults(3, 0, -5, -20, 5, 21) },
                    { Item.StarAtomizer, new FeedingResults(3, -2, 4, 6, 8, 5) }
                }
            },
            {
                new Dictionary<Item, FeedingResults> {
                    { Item.Monomate, new FeedingResults(2, -1, -4, 13, -5, -5) },
                    { Item.Dimate, new FeedingResults(0, 1, 0, 16, 0, -15) },
                    { Item.Trimate, new FeedingResults(2, 0, 3, 19, -2, -18) },
                    { Item.Monofluid, new FeedingResults(2, -1, -4, -5, -5, 13) },
                    { Item.Difluid, new FeedingResults(0, 1, 0, -15, 0, 16) },
                    { Item.Trifluid, new FeedingResults(2, 0, 3, -20, 0, 19) },
                    { Item.Antidote, new FeedingResults(0, 1, 5, -6, 6, -5) },
                    { Item.Antiparalysis, new FeedingResults(-1, 1, 0, -4, 14, -10) },
                    { Item.SolAtomizer, new FeedingResults(4, -1, 4, 17, -5, -15) },
                    { Item.MoonAtomizer, new FeedingResults(2, 0, -10, -15, 5, 21) },
                    { Item.StarAtomizer, new FeedingResults(3, 2, 2, 8, 3, 6) }
                }
            },
            {
                new Dictionary<Item, FeedingResults> {
                    { Item.Monomate, new FeedingResults(-1, 1, -3, 9, -3, -4) },
                    { Item.Dimate, new FeedingResults(2, 0, 0, 11, 0, -10) },
                    { Item.Trimate, new FeedingResults(2, 0, 2, 15, 0, -16) },
                    { Item.Monofluid, new FeedingResults(-1, 3, -3, -4, -3, 9) },
                    { Item.Difluid, new FeedingResults(2, 0, 0, -10, 0, 11) },
                    { Item.Trifluid, new FeedingResults(2, 0, -2, -15, 0, 19) },
                    { Item.Antidote, new FeedingResults(2, -1, 0, 6, 9, -15) },
                    { Item.Antiparalysis, new FeedingResults(-2, 3, 0, -15, 9, 6) },
                    { Item.SolAtomizer, new FeedingResults(3, -1, 9, -20, -5, 17) },
                    { Item.MoonAtomizer, new FeedingResults(0, 2, -5, 20, 5, -20) },
                    { Item.StarAtomizer, new FeedingResults(3, 2, 0, 11, 0, 11) }
                }
            },
            {
                new Dictionary<Item, FeedingResults> {
                    { Item.Monomate, new FeedingResults(-1, 0, -4, 21, -15, -5) },
                    { Item.Dimate, new FeedingResults(0, 1, -1, 27, -10, -16) },
                    { Item.Trimate, new FeedingResults(2, 0, 5, 29, -7, -25) },
                    { Item.Monofluid, new FeedingResults(-1, 0, -10, -5, -10, 21) },
                    { Item.Difluid, new FeedingResults(0, 1, -5, -16, -5, 25) },
                    { Item.Trifluid, new FeedingResults(2, 0, -7, -25, 6, 29) },
                    { Item.Antidote, new FeedingResults(-1, 1, -10, -10, 28, -10) },
                    { Item.Antiparalysis, new FeedingResults(2, -1, 9, -18, 24, -15) },
                    { Item.SolAtomizer, new FeedingResults(2, 1, 19, 18, -15, -20) },
                    { Item.MoonAtomizer, new FeedingResults(2, 1, -15, -20, 19, 18) },
                    { Item.StarAtomizer, new FeedingResults(4, 2, 3, 7, 3, 3) }
                }
            }
        };
    }
}
