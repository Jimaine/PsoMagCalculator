using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsoMagCalculator
{
  class FeedingResults
  {
    private int sync;
    private int iQ;
    private int def;
    private int pow;
    private int dex;
    private int mind;

    public FeedingResults(int syncInc, int iqInc, int defInc, int powInc, int dexInc, int mindInc)
    {
      sync = syncInc;
      iQ = iqInc;
      def = defInc;
      pow = powInc;
      dex = dexInc;
      mind = mindInc;
    }

    /// <summary>
    /// Adds corresponding values of FeedingResults to the Mag.
    /// </summary>
    /// <param name="p_Mag">The Mag to Apply the Values</param>
    public void AddToMag(Mag p_Mag)
    {
      p_Mag.Sync += sync;
      p_Mag.IQ += iQ;
      p_Mag.DefValue += def;
      p_Mag.PowValue += pow;
      p_Mag.DexValue += dex;
      p_Mag.MindValue += mind;
    }
  }
}
