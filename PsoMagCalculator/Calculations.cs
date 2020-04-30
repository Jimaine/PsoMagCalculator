using System;

namespace PsoMagCalculator
{
    static class Calculations
    {
        private static readonly MagFeedingTable magFeedingTable = new MagFeedingTable();

        /// <summary>
        /// Modifies the values of the Main Mag.
        /// </summary>
        /// <param name="mag">The Mag to modify.</param>
        /// <param name="item">The Item to feed the Mag.</param>
        /// <param name="character">The character who feed the Mag.</param>
        /// <param name="sectionId">The Id of the character who feed the Mag.</param>
        public static void Recalculate(Mag mag, Item item, Character character, SectionId sectionId)
        {
            SetMag(mag, item);

            CheckLimits(mag);
            CheckLevel(mag, character, sectionId);
            CheckCosts(mag, item);
        }

        /// <summary>
        /// Return the Button's Tooltip as a string.
        /// </summary>
        /// <param name="item">The Item which represents the button.</param>
        /// <param name="magName">The Name of the Main Mag.</param>
        /// <returns>string</returns>
        public static string GetTooltip(Item item, MagName magName)
        {
            var mag = new Mag { Name = magName };
            SetMag(mag, item);

            return $"{item}\n\n{GetHoverText(mag)}";
        }

        private static string GetHoverText(Mag mag)
        {
            return $"IQ: {mag.IQ}\nSync: {mag.Sync}\nDef: {mag.DefValue}\nPow: {mag.PowValue}\nDex: {mag.DexValue}\nMind: {mag.MindValue}";
        }
         
        private static void SetMag(Mag mag, Item item)
        {
            switch (mag.Name)
            {
                case MagName.Mag:
                    magFeedingTable.FeedingTables[0][item].AddToMag(mag);
                    break;
                case MagName.Varuna:
                case MagName.Vritra:
                case MagName.Kalki:
                    magFeedingTable.FeedingTables[1][item].AddToMag(mag);
                    break;
                case MagName.Ashvinau:
                case MagName.Sumba:
                case MagName.Namuci:
                case MagName.Marutah:
                case MagName.Rudra:
                    magFeedingTable.FeedingTables[2][item].AddToMag(mag);
                    break;
                case MagName.Surya:
                case MagName.Tapas:
                case MagName.Mitra:
                    magFeedingTable.FeedingTables[3][item].AddToMag(mag);
                    break;
                case MagName.Asperus:
                case MagName.Vayu:
                case MagName.Varaha:
                case MagName.Ushasu:
                case MagName.Kama:
                case MagName.Kaitabha:
                case MagName.Kumara:
                case MagName.Bhirava:
                    magFeedingTable.FeedingTables[4][item].AddToMag(mag);
                    break;
                case MagName.Ila:
                case MagName.Garuda:
                case MagName.Sita:
                case MagName.Soma:
                case MagName.Durga:
                case MagName.Nandin:
                case MagName.Yaksa:
                case MagName.Ribhava:
                case MagName.Deva:
                case MagName.Rukmin:
                case MagName.Sato:
                    magFeedingTable.FeedingTables[5][item].AddToMag(mag);
                    break;
                case MagName.Andhaka:
                case MagName.Kabanda:
                case MagName.Naga:
                case MagName.Naraka:
                case MagName.Bana:
                case MagName.Marica:
                case MagName.Madhu:
                case MagName.Ravana:
                case MagName.Bhima:
                case MagName.Pushan:
                case MagName.Rati:
                    magFeedingTable.FeedingTables[6][item].AddToMag(mag);
                    break;
                case MagName.Savitri:
                case MagName.Diwari:
                case MagName.Nidra:
                    magFeedingTable.FeedingTables[7][item].AddToMag(mag);
                    break;
            }
        }

        private static void CheckLimits(Mag mag)
        {
            if (mag.IQ > 200) mag.IQ = 200;
            if (mag.IQ < 0) mag.IQ = 0;

            if (mag.Sync > 120) mag.Sync = 120;
            if (mag.Sync < 0) mag.Sync = 0;

            if (mag.DefValue > 100) mag.DefValue = 100;
            if (mag.DefValue < 0) mag.DefValue = 0;

            if (mag.PowValue > 100) mag.PowValue = 100;
            if (mag.PowValue < 0) mag.PowValue = 0;

            if (mag.DexValue > 100) mag.DexValue = 100;
            if (mag.DexValue < 0) mag.DexValue = 0;

            if (mag.MindValue > 100) mag.MindValue = 100;
            if (mag.MindValue < 0) mag.MindValue = 0;
        }

        private static void CheckLevel(Mag mag, Character character, SectionId sectionId)
        {
            int levelUps = SetLevel(mag);

            // Mag Change only for non-epic.
            if (mag.Name != MagName.Rukmin && mag.Name != MagName.Bhima && mag.Name != MagName.Nidra && mag.Name != MagName.Rukmin && mag.Name != MagName.Pushan && mag.Name != MagName.Savitri && mag.Name != MagName.Rati && mag.Name != MagName.Sato && mag.Name != MagName.Deva && mag.Name != MagName.Diwari)
                if (levelUps >= 1)
                    for (int i = 0; i < levelUps; i++)
                        CheckMagChange(mag, character, sectionId);
        }

        private static int SetLevel(Mag mag)
        {
            int levelUp = 0;

            if ((mag.Level + levelUp) < 200)
                if (mag.DefValue == 100)
                {
                    mag.DefLevel++;
                    mag.DefValue = 0;
                    levelUp++;
                }

            if ((mag.Level + levelUp) < 200)
                if (mag.PowValue == 100)
                {
                    mag.PowLevel++;
                    mag.PowValue = 0;
                    levelUp++;
                }

            if ((mag.Level + levelUp) < 200)
                if (mag.DexValue == 100)
                {
                    mag.DexLevel++;
                    mag.DexValue = 0;
                    levelUp++;
                }

            if ((mag.Level + levelUp) < 200)
                if (mag.MindValue == 100)
                {
                    mag.MindLevel++;
                    mag.MindValue = 0;
                    levelUp++;
                }

            mag.Level += levelUp;

            return levelUp;
        }

        private static void CheckMagChange(Mag mag, Character character, SectionId sectionId)
        {
            switch (mag.Level)
            {
                case 10:
                case 11:
                case 12:
                case 13:
                    if (mag.Name == MagName.Mag)
                        FirstMagChange(mag, character);
                    break;
                case 35:
                case 36:
                case 37:
                case 38:
                    if (mag.Name == MagName.Varuna || mag.Name == MagName.Kalki || mag.Name == MagName.Vritra)
                        SecondMagChange(mag, character);
                    break;
                default:
                    if (mag.Level >= 50 && (mag.Level % 5) == 0)
                        EndMagChange(mag, character, sectionId);
                    break;
            }
        }

        private static void FirstMagChange(Mag mag, Character character)
        {
            switch (character)
            {
                case Character.HunterMale:
                case Character.HunterFemale:
                    mag.Name = MagName.Varuna;
                    mag.PhotonBlasts.Add(PhotonBlast.Farlla);
                    break;
                case Character.RangerMale:
                case Character.RangerFemale:
                    mag.Name = MagName.Kalki;
                    mag.PhotonBlasts.Add(PhotonBlast.Estlla);
                    break;
                case Character.ForceMale:
                case Character.ForceFemale:
                    mag.Name = MagName.Vritra;
                    mag.PhotonBlasts.Add(PhotonBlast.Leilla);
                    break;
            }
        }

        private static void SecondMagChange(Mag mag, Character character)
        {
            switch (character)
            {
                case Character.HunterMale:
                case Character.HunterFemale:
                    if (mag.PowLevel > mag.DexLevel && mag.PowLevel > mag.MindLevel)
                    {
                        mag.Name = MagName.Rudra;
                        mag.PhotonBlasts.Add(PhotonBlast.Golla);
                    }
                    else if (mag.DexLevel > mag.PowLevel && mag.DexLevel > mag.MindLevel)
                    {
                        mag.Name = MagName.Marutah;
                        mag.PhotonBlasts.Add(PhotonBlast.Pilla);
                    }
                    else if (mag.MindLevel > mag.PowLevel && mag.MindLevel > mag.DexLevel)
                    {
                        mag.Name = MagName.Vayu;
                        mag.PhotonBlasts.Add(PhotonBlast.MyllaAndYoulla);
                    }
                    else
                    {
                        mag.Name = MagName.Rudra;
                        mag.PhotonBlasts.Add(PhotonBlast.Leilla);
                    }
                    break;
                case Character.RangerMale:
                case Character.RangerFemale:
                    if (mag.PowLevel > mag.DexLevel && mag.PowLevel > mag.MindLevel)
                    {
                        mag.Name = MagName.Surya;
                        mag.PhotonBlasts.Add(PhotonBlast.Golla);
                    }
                    else if (mag.DexLevel > mag.PowLevel && mag.DexLevel > mag.MindLevel)
                    {
                        mag.Name = MagName.Mitra;
                        mag.PhotonBlasts.Add(PhotonBlast.Pilla);
                    }
                    else if (mag.MindLevel > mag.PowLevel && mag.MindLevel > mag.DexLevel)
                    {
                        mag.Name = MagName.Tapas;
                        mag.PhotonBlasts.Add(PhotonBlast.MyllaAndYoulla);
                    }
                    else
                    {
                        mag.Name = MagName.Mitra;
                        mag.PhotonBlasts.Add(PhotonBlast.Leilla);
                    }
                    break;
                case Character.ForceMale:
                case Character.ForceFemale:
                    if (mag.PowLevel > mag.DexLevel && mag.PowLevel > mag.MindLevel)
                    {
                        mag.Name = MagName.Sumba;
                        mag.PhotonBlasts.Add(PhotonBlast.Golla);
                    }
                    else if (mag.DexLevel > mag.PowLevel && mag.DexLevel > mag.MindLevel)
                    {
                        mag.Name = MagName.Ashvinau;
                        mag.PhotonBlasts.Add(PhotonBlast.Pilla);
                    }
                    else if (mag.MindLevel > mag.PowLevel && mag.MindLevel > mag.DexLevel)
                    {
                        mag.Name = MagName.Namuci;
                        mag.PhotonBlasts.Add(PhotonBlast.MyllaAndYoulla);
                    }
                    else
                    {
                        mag.Name = MagName.Namuci;
                        mag.PhotonBlasts.Add(PhotonBlast.MyllaAndYoulla);
                    }
                    break;
            }
        }

        private static void EndMagChange(Mag mag, Character character, SectionId sectionId)
        {
            switch (sectionId)
            {
                case SectionId.Viridia:
                case SectionId.Skyly:
                case SectionId.Purplenum:
                case SectionId.Redria:
                case SectionId.Yellowboze:
                    switch (character)
                    {
                        case Character.HunterMale:
                        case Character.HunterFemale:
                            if (mag.PowLevel > mag.DexLevel && mag.PowLevel > mag.MindLevel)
                            {
                                // POW is First, look for second.
                                if (mag.DexLevel >= mag.MindLevel)
                                    mag.Name = MagName.Varaha;
                                else
                                    mag.Name = MagName.Bhirava;
                            }
                            else if (mag.DexLevel > mag.PowLevel && mag.DexLevel > mag.MindLevel)
                            {
                                // Dex is First, look for second.
                                if (mag.MindLevel >= mag.PowLevel)
                                    mag.Name = MagName.Nandin;
                                else
                                    mag.Name = MagName.Ila;
                            }
                            else if (mag.MindLevel > mag.PowLevel && mag.MindLevel > mag.DexLevel)
                            {
                                // Mind is First, look for second.
                                if (mag.PowLevel >= mag.DexLevel)
                                    mag.Name = MagName.Kabanda;
                                else
                                    mag.Name = MagName.Ushasu;
                            }
                            else
                            {
                                // Tie of Pow/Dex/Mind, look for second.
                                if (mag.DexLevel >= mag.MindLevel)
                                    mag.Name = MagName.Varaha;
                                else
                                    mag.Name = MagName.Bhirava;
                            }
                            break;
                        case Character.RangerMale:
                        case Character.RangerFemale:
                            if (mag.PowLevel > mag.DexLevel && mag.PowLevel > mag.MindLevel)
                            {
                                if (mag.DexLevel >= mag.MindLevel)
                                    mag.Name = MagName.Kama;
                                else
                                    mag.Name = MagName.Bhirava;
                            }
                            else if (mag.DexLevel > mag.PowLevel && mag.DexLevel > mag.MindLevel)
                            {
                                if (mag.MindLevel >= mag.PowLevel)
                                    mag.Name = MagName.Kama;
                                else
                                    mag.Name = MagName.Bhirava;
                            }
                            else if (mag.MindLevel > mag.PowLevel && mag.MindLevel > mag.DexLevel)
                            {
                                if (mag.PowLevel >= mag.DexLevel)
                                    mag.Name = MagName.Varaha;
                                else
                                    mag.Name = MagName.Asperus;
                            }
                            else
                            {
                                if (mag.MindLevel >= mag.PowLevel)
                                    mag.Name = MagName.Kama;
                                else
                                    mag.Name = MagName.Bhirava;
                            }
                            break;
                        case Character.ForceMale:
                        case Character.ForceFemale:
                            if (mag.PowLevel > mag.DexLevel && mag.PowLevel > mag.MindLevel)
                            {
                                if (mag.DefLevel >= 45)
                                    mag.Name = MagName.Andhaka; // special def mag for Force.
                                else
                                  if (mag.DexLevel >= mag.MindLevel)
                                    mag.Name = MagName.Naraka;
                                else
                                    mag.Name = MagName.Ravana;
                            }
                            else if (mag.DexLevel > mag.PowLevel && mag.DexLevel > mag.MindLevel)
                            {
                                if (mag.DefLevel >= 45)
                                    mag.Name = MagName.Bana; // special def mag for Force.
                                else
                                  if (mag.MindLevel >= mag.PowLevel)
                                    mag.Name = MagName.Sita;
                                else
                                    mag.Name = MagName.Ribhava;
                            }
                            else if (mag.MindLevel > mag.PowLevel && mag.MindLevel > mag.DexLevel)
                            {
                                if (mag.DefLevel >= 45)
                                    mag.Name = MagName.Bana; // special def mag for Force.
                                else
                                  if (mag.PowLevel >= mag.DexLevel)
                                    mag.Name = MagName.Naga;
                                else
                                    mag.Name = MagName.Kabanda;
                            }
                            else
                            {
                                if (mag.DefLevel >= 45)
                                    mag.Name = MagName.Bana; // special def mag for Force.
                                else
                                  if (mag.PowLevel >= mag.DexLevel)
                                    mag.Name = MagName.Naga;
                                else
                                    mag.Name = MagName.Kabanda;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case SectionId.Greennill:
                case SectionId.Bluefull:
                case SectionId.Pinkal:
                case SectionId.Oran:
                case SectionId.Whitill:
                    switch (character)
                    {
                        case Character.HunterMale:
                        case Character.HunterFemale:
                            if (mag.PowLevel > mag.DexLevel && mag.PowLevel > mag.MindLevel)
                            {
                                // POW is First, look for second.
                                if (mag.DexLevel >= mag.MindLevel)
                                    mag.Name = MagName.Kama;
                                else
                                    mag.Name = MagName.Asperus;
                            }
                            else if (mag.DexLevel > mag.PowLevel && mag.DexLevel > mag.MindLevel)
                            {
                                // Dex is First, look for second.
                                if (mag.MindLevel >= mag.PowLevel)
                                    mag.Name = MagName.Yaksa;
                                else
                                    mag.Name = MagName.Garuda;
                            }
                            else if (mag.MindLevel > mag.PowLevel && mag.MindLevel > mag.DexLevel)
                            {
                                // Mind is First, look for second.
                                if (mag.PowLevel >= mag.DexLevel)
                                    mag.Name = MagName.Bana;
                                else
                                    mag.Name = MagName.Soma;
                            }
                            else
                            {
                                // Tie of Pow/Dex/Mind, look for second.
                                if (mag.DexLevel >= mag.MindLevel)
                                    mag.Name = MagName.Kama;
                                else
                                    mag.Name = MagName.Asperus;
                            }
                            break;
                        case Character.RangerMale:
                        case Character.RangerFemale:
                            if (mag.PowLevel > mag.DexLevel && mag.PowLevel > mag.MindLevel)
                            {
                                if (mag.DexLevel >= mag.MindLevel)
                                    mag.Name = MagName.Madhu;
                                else
                                    mag.Name = MagName.Kaitabha;
                            }
                            else if (mag.DexLevel > mag.PowLevel && mag.DexLevel > mag.MindLevel)
                            {
                                if (mag.MindLevel >= mag.PowLevel)
                                    mag.Name = MagName.Varaha;
                                else
                                    mag.Name = MagName.Kaitabha;
                            }
                            else if (mag.MindLevel > mag.PowLevel && mag.MindLevel > mag.DexLevel)
                            {
                                if (mag.PowLevel >= mag.DexLevel)
                                    mag.Name = MagName.Kabanda;
                                else
                                    mag.Name = MagName.Durga;
                            }
                            else
                            {
                                if (mag.MindLevel >= mag.PowLevel)
                                    mag.Name = MagName.Varaha;
                                else
                                    mag.Name = MagName.Kaitabha;
                            }
                            break;
                        case Character.ForceMale:
                        case Character.ForceFemale:
                            if (mag.PowLevel > mag.DexLevel && mag.PowLevel > mag.MindLevel)
                            {
                                if (mag.DefLevel >= 45)
                                    mag.Name = MagName.Andhaka; // special def mag for Force. Perhaps Pow > Dex + Mind.
                                else
                                  if (mag.DexLevel >= mag.MindLevel)
                                    mag.Name = MagName.Marica;
                                else
                                    mag.Name = MagName.Naga;
                            }
                            else if (mag.DexLevel > mag.PowLevel && mag.DexLevel > mag.MindLevel)
                            {
                                if (mag.DefLevel >= 45)
                                    mag.Name = MagName.Bana; // special def mag for Force. Perhaps Dex > Pow + Mind.
                                else
                                  if (mag.MindLevel >= mag.PowLevel)
                                    mag.Name = MagName.Bhirava;
                                else
                                    mag.Name = MagName.Garuda;
                            }
                            else if (mag.MindLevel > mag.PowLevel && mag.MindLevel > mag.DexLevel)
                            {
                                if (mag.DefLevel >= 45)
                                    mag.Name = MagName.Bana; // special def mag for Force. Perhaps Mind > Pow + Dex.
                                else
                                  if (mag.PowLevel >= mag.DexLevel)
                                    mag.Name = MagName.Kumara;
                                else
                                    mag.Name = MagName.Ila;
                            }
                            else
                            {
                                if (mag.DefLevel >= 45)
                                    mag.Name = MagName.Bana; // special def mag for Force. Perhaps Mind > Pow + Dex.
                                else
                                  if (mag.PowLevel >= mag.DexLevel)
                                    mag.Name = MagName.Kumara;
                                else
                                    mag.Name = MagName.Ila;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
            }

            GetLastPhotonBlast(mag);

            if (mag.Level > 99)
                MagChangeEpic(mag, character, sectionId);
        }

        private static void GetLastPhotonBlast(Mag mag)
        {
            if (mag.PhotonBlasts.Count == 2)
                switch (mag.Name)
                {
                    case MagName.Asperus:
                    case MagName.Andhaka:
                    case MagName.Soma:
                    case MagName.Durga:
                    case MagName.Nandin:
                    case MagName.Bana:
                        CheckPhotonBlast(mag, PhotonBlast.Estlla);
                        break;
                    case MagName.Ribhava:
                    case MagName.Ravana:
                        CheckPhotonBlast(mag, PhotonBlast.Farlla);
                        break;
                    case MagName.Ushasu:
                    case MagName.Varaha:
                    case MagName.Kumara:
                    case MagName.Yaksa:
                    case MagName.Naraka:
                        CheckPhotonBlast(mag, PhotonBlast.Golla);
                        break;
                    case MagName.Kaitabha:
                    case MagName.Ila:
                    case MagName.Kabanda:
                    case MagName.Naga:
                    case MagName.Madhu:
                        CheckPhotonBlast(mag, PhotonBlast.MyllaAndYoulla);
                        break;
                    case MagName.Kama:
                    case MagName.Bhirava:
                    case MagName.Garuda:
                    case MagName.Sita:
                    case MagName.Marica:
                        CheckPhotonBlast(mag, PhotonBlast.Pilla);
                        break;
                }
        }

        private static void CheckPhotonBlast(Mag mag, PhotonBlast photonBlast)
        {
            bool flag = false;

            foreach (PhotonBlast pb in mag.PhotonBlasts)
                if (pb != photonBlast)
                    flag = true;

            if (flag)
                mag.PhotonBlasts.Add(photonBlast);
        }

        private static void MagChangeEpic(Mag mag, Character character, SectionId sectionId)
        {
            switch (sectionId)
            {
                case SectionId.Skyly:
                case SectionId.Yellowboze:
                case SectionId.Pinkal:
                    if ((mag.DefLevel + mag.PowLevel) == (mag.DexLevel + mag.MindLevel))
                        switch (character)
                        {
                            case Character.HunterMale:
                                mag.Name = MagName.Rati;
                                break;
                            case Character.HunterFemale:
                                mag.Name = MagName.Savitri;
                                break;
                            case Character.RangerMale:
                                mag.Name = MagName.Pushan;
                                break;
                            case Character.RangerFemale:
                                mag.Name = MagName.Diwari;
                                break;
                            case Character.ForceMale:
                                mag.Name = MagName.Nidra;
                                break;
                            case Character.ForceFemale:
                                mag.Name = MagName.Bhima;
                                break;
                        }
                    break;
                case SectionId.Bluefull:
                case SectionId.Viridia:
                case SectionId.Whitill:
                case SectionId.Redria:
                    if ((mag.DefLevel + mag.DexLevel) == (mag.PowLevel + mag.MindLevel))
                        switch (character)
                        {
                            case Character.HunterMale:
                                mag.Name = MagName.Deva;
                                break;
                            case Character.HunterFemale:
                                mag.Name = MagName.Savitri;
                                break;
                            case Character.RangerMale:
                                mag.Name = MagName.Pushan;
                                break;
                            case Character.RangerFemale:
                                mag.Name = MagName.Rukmin;
                                break;
                            case Character.ForceMale:
                                mag.Name = MagName.Nidra;
                                break;
                            case Character.ForceFemale:
                                mag.Name = MagName.Sato;
                                break;
                        }
                    break;
                case SectionId.Oran:
                case SectionId.Greennill:
                case SectionId.Purplenum:
                    if ((mag.DefLevel + mag.MindLevel) == (mag.DexLevel + mag.PowLevel))
                        switch (character)
                        {
                            case Character.HunterMale:
                                mag.Name = MagName.Rati;
                                break;
                            case Character.HunterFemale:
                                mag.Name = MagName.Savitri;
                                break;
                            case Character.RangerMale:
                                mag.Name = MagName.Pushan;
                                break;
                            case Character.RangerFemale:
                                mag.Name = MagName.Rukmin;
                                break;
                            case Character.ForceMale:
                                mag.Name = MagName.Nidra;
                                break;
                            case Character.ForceFemale:
                                mag.Name = MagName.Bhima;
                                break;
                        }
                    break;
            }
        }

        private static void CheckCosts(Mag mag, Item item)
        {
            switch (item)
            {
                case Item.Monomate:
                    mag.Meseta += 50;
                    break;
                case Item.Dimate:
                    mag.Meseta += 300;
                    break;
                case Item.Trimate:
                    mag.Meseta += 2000;
                    break;
                case Item.Monofluid:
                    mag.Meseta += 100;
                    break;
                case Item.Difluid:
                    mag.Meseta += 500;
                    break;
                case Item.Trifluid:
                    mag.Meseta += 3600;
                    break;
                case Item.Antidote:
                    mag.Meseta += 60;
                    break;
                case Item.Antiparalysis:
                    mag.Meseta += 60;
                    break;
                case Item.SolAtomizer:
                    mag.Meseta += 300;
                    break;
                case Item.MoonAtomizer:
                    mag.Meseta += 500;
                    break;
                case Item.StarAtomizer:
                    mag.Meseta += 5000;
                    break;
                default:
                    break;
            }
        }
    }
}
