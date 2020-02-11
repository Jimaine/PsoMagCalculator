using System;
using System.Collections.Generic;

namespace PsoMagCalculator
{
    [Serializable]
    class Mag
    {
        public List<PhotonBlast> PhotonBlasts { get; set; } = new List<PhotonBlast>();

        public MagName Name { get; set; } = MagName.Mag;

        public int Level { get; set; } = 5;

        public int Sync { get; set; } = 0;

        public int IQ { get; set; } = 0;

        /// <summary>
        /// The def value of the bar.
        /// </summary>
        public int DefValue { get; set; } = 0;

        /// <summary>
        /// The pow value of the bar.
        /// </summary>
        public int PowValue { get; set; } = 0;

        /// <summary>
        /// The dex value of the bar.
        /// </summary>
        public int DexValue { get; set; } = 0;

        /// <summary>
        /// The mind value of the bar.
        /// </summary>
        public int MindValue { get; set; } = 0;

        /// <summary>
        /// The whole def level.
        /// </summary>
        public int DefLevel { get; set; } = 5;

        /// <summary>
        /// The whole pow level.
        /// </summary>
        public int PowLevel { get; set; } = 0;

        /// <summary>
        /// The whole dex level.
        /// </summary>
        public int DexLevel { get; set; } = 0;

        /// <summary>
        /// The whole mind level.
        /// </summary>
        public int MindLevel { get; set; } = 0;

        public int Meseta { get; set; } = 0;
    }
}
