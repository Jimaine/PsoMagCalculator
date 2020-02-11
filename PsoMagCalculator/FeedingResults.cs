using System;

namespace PsoMagCalculator
{
    class FeedingResults
    {
        private readonly int sync;
        private readonly int iQ;
        private readonly int def;
        private readonly int pow;
        private readonly int dex;
        private readonly int mind;

        /// <summary>
        /// Basic constructor to set all feeding results.
        /// </summary>
        /// <param name="syncInc">increment for sync attribute.</param>
        /// <param name="iqInc">increment for iq attribute.</param>
        /// <param name="defInc">increment for def attribute.</param>
        /// <param name="powInc">increment for pow attribute.</param>
        /// <param name="dexInc">increment for dex attribute.</param>
        /// <param name="mindInc">increment for mind attribute.</param>
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
        /// <param name="mag">The Mag to Apply the Values.</param>
        public void AddToMag(Mag mag)
        {
            mag.Sync += sync;
            mag.IQ += iQ;
            mag.DefValue += def;
            mag.PowValue += pow;
            mag.DexValue += dex;
            mag.MindValue += mind;
        }
    }
}
