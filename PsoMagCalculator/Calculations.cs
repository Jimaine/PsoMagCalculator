using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsoMagCalculator
{
  static class Calculations
  {
    public static string GetTooltip(Item p_item, MagName p_magName)
    {
      Mag tmpMag = new Mag();

      switch (p_magName)
      {
        case MagName.Mag:
          MagTableOne(ref tmpMag, p_item);
          break;
        case MagName.Varuna:
        case MagName.Vritra:
        case MagName.Kalki:
          MagTableTwo(ref tmpMag, p_item);
          break;
        case MagName.Ashvinau:
        case MagName.Sumba:
        case MagName.Namuci:
        case MagName.Marutah:
        case MagName.Rudra:
          MagTableThree(ref tmpMag, p_item);
          break;
        case MagName.Surya:
        case MagName.Tapas:
        case MagName.Mitra:
          MagTableFour(ref tmpMag, p_item);
          break;
        case MagName.Asperus:
        case MagName.Vayu:
        case MagName.Varaha:
        case MagName.Ushasu:
        case MagName.Kama:
        case MagName.Kaitabha:
        case MagName.Kumara:
        case MagName.Bhirava:
          MagTableFive(ref tmpMag, p_item);
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
          MagTableSix(ref tmpMag, p_item);
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
          MagTableSeven(ref tmpMag, p_item);
          break;
        case MagName.Savitri:
        case MagName.Diwari:
        case MagName.Nidra:
          MagTableEight(ref tmpMag, p_item);
          break;
      }

      return p_item.ToString() + "\n\n" + GetHoverText(tmpMag);
    }

    private static string GetHoverText(Mag p_mag)
    {
      return String.Format("IQ: {0}\nSync: {1}\nDef: {2}\nPow: {3}\nDex: {4}\nMind: {5}", p_mag.IQ, p_mag.Sync, p_mag.DefValue, p_mag.PowValue, p_mag.DexValue, p_mag.MindValue);
    }

    public static void Recalculate(ref Mag p_mag, Item p_item, Character p_character, SectionId p_sectionId)
    {
      switch (p_mag.Name)
      {
        case MagName.Mag:
          MagTableOne(ref p_mag, p_item);
          break;
        case MagName.Varuna:
        case MagName.Vritra:
        case MagName.Kalki:
          MagTableTwo(ref p_mag, p_item);
          break;
        case MagName.Ashvinau:
        case MagName.Sumba:
        case MagName.Namuci:
        case MagName.Marutah:
        case MagName.Rudra:
          MagTableThree(ref p_mag, p_item);
          break;
        case MagName.Surya:
        case MagName.Tapas:
        case MagName.Mitra:
          MagTableFour(ref p_mag, p_item);
          break;
        case MagName.Asperus:
        case MagName.Vayu:
        case MagName.Varaha:
        case MagName.Ushasu:
        case MagName.Kama:
        case MagName.Kaitabha:
        case MagName.Kumara:
        case MagName.Bhirava:
          MagTableFive(ref p_mag, p_item);
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
          MagTableSix(ref p_mag, p_item);
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
          MagTableSeven(ref p_mag, p_item);
          break;
        case MagName.Savitri:
        case MagName.Diwari:
        case MagName.Nidra:
          MagTableEight(ref p_mag, p_item);
          break;
      }

      CheckLimits(ref p_mag);
      CheckLevel(ref p_mag, p_character, p_sectionId);
      CheckCosts(ref p_mag, p_item);
    }

    private static void MagTableOne(ref Mag p_mag, Item p_item)
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

    private static void MagTableTwo(ref Mag p_mag, Item p_item)
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

    private static void MagTableThree(ref Mag p_mag, Item p_item)
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

    private static void MagTableFour(ref Mag p_mag, Item p_item)
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

    private static void MagTableFive(ref Mag p_mag, Item p_item)
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

    private static void MagTableSix(ref Mag p_mag, Item p_item)
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

    private static void MagTableSeven(ref Mag p_mag, Item p_item)
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

    private static void MagTableEight(ref Mag p_mag, Item p_item)
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

    private static void CheckLimits(ref Mag p_mag)
    {
      if (p_mag.IQ > 200) p_mag.IQ = 200;
      if (p_mag.IQ < 0) p_mag.IQ = 0;

      if (p_mag.Sync > 120) p_mag.Sync = 120;
      if (p_mag.Sync < 0) p_mag.Sync = 0;

      if (p_mag.DefValue > 100) p_mag.DefValue = 100;
      if (p_mag.DefValue < 0) p_mag.DefValue = 0;

      if (p_mag.PowValue > 100) p_mag.PowValue = 100;
      if (p_mag.PowValue < 0) p_mag.PowValue = 0;

      if (p_mag.DexValue > 100) p_mag.DexValue = 100;
      if (p_mag.DexValue < 0) p_mag.DexValue = 0;

      if (p_mag.MindValue > 100) p_mag.MindValue = 100;
      if (p_mag.MindValue < 0) p_mag.MindValue = 0;
    }

    private static void CheckLevel(ref Mag p_mag, Character p_character, SectionId p_sectionId)
    {
      int tmpLevel = p_mag.Level;
      int levelUps = SetLevel(ref p_mag);

      if (p_mag.Name != MagName.Rukmin && p_mag.Name != MagName.Bhima && p_mag.Name != MagName.Nidra && p_mag.Name != MagName.Rukmin && p_mag.Name != MagName.Pushan && p_mag.Name != MagName.Savitri && p_mag.Name != MagName.Rati && p_mag.Name != MagName.Sato && p_mag.Name != MagName.Deva && p_mag.Name != MagName.Diwari)
        if (levelUps >= 1)
          for (int i = 0; i < levelUps; i++)
          {
            switch (p_mag.Level)
            {
              case 10:
              case 11:
              case 12:
              case 13:
                if (p_mag.Name == MagName.Mag)
                  MagChangeOne(ref p_mag, p_character);
                break;
              case 35:
              case 36:
              case 37:
              case 38:
                if (p_mag.Name == MagName.Varuna || p_mag.Name == MagName.Kalki || p_mag.Name == MagName.Vritra)
                  MagChangeTwo(ref p_mag, p_character);
                break;
              case 200:
                MagChangeThree(ref p_mag, p_character, p_sectionId);
                break;
              default:
                if (p_mag.Level >= 50 && (p_mag.Level % 5) == 0)
                  MagChangeThree(ref p_mag, p_character, p_sectionId);
                break;
            }
          }
    }

    private static int SetLevel(ref Mag p_mag)
    {
      int levelUp = 0;

      if ((p_mag.Level + levelUp) < 200)
        if (p_mag.DefValue == 100)
        {
          p_mag.DefLevel++;
          p_mag.DefValue = 0;
          levelUp++;
        }

      if ((p_mag.Level + levelUp) < 200)
        if (p_mag.PowValue == 100)
        {
          p_mag.PowLevel++;
          p_mag.PowValue = 0;
          levelUp++;
        }

      if ((p_mag.Level + levelUp) < 200)
        if (p_mag.DexValue == 100)
        {
          p_mag.DexLevel++;
          p_mag.DexValue = 0;
          levelUp++;
        }

      if ((p_mag.Level + levelUp) < 200)
        if (p_mag.MindValue == 100)
        {
          p_mag.MindLevel++;
          p_mag.MindValue = 0;
          levelUp++;
        }

      p_mag.Level += levelUp;

      return levelUp;
    }

    private static void MagChangeOne(ref Mag p_mag, Character p_character)
    {
      switch (p_character)
      {
        case Character.HunterMale:
        case Character.HunterFemale:
          p_mag.Name = MagName.Varuna;
          p_mag.PhotonBlasts.Add(PhotonBlast.Farlla);
          break;
        case Character.RangerMale:
        case Character.RangerFemale:
          p_mag.Name = MagName.Kalki;
          p_mag.PhotonBlasts.Add(PhotonBlast.Estlla);
          break;
        case Character.ForceMale:
        case Character.ForceFemale:
          p_mag.Name = MagName.Vritra;
          p_mag.PhotonBlasts.Add(PhotonBlast.Leilla);
          break;
      }
    }

    private static void MagChangeTwo(ref Mag p_mag, Character p_character)
    {
      switch (p_character)
      {
        case Character.HunterMale:
        case Character.HunterFemale:
          if (p_mag.PowLevel > p_mag.DexLevel && p_mag.PowLevel > p_mag.MindLevel)
          {
            p_mag.Name = MagName.Rudra;
            p_mag.PhotonBlasts.Add(PhotonBlast.Golla);
          }
          else if (p_mag.DexLevel > p_mag.PowLevel && p_mag.DexLevel > p_mag.MindLevel)
          {
            p_mag.Name = MagName.Marutah;
            p_mag.PhotonBlasts.Add(PhotonBlast.Pilla);
          }
          else if (p_mag.MindLevel > p_mag.PowLevel && p_mag.MindLevel > p_mag.DexLevel)
          {
            p_mag.Name = MagName.Vayu;
            p_mag.PhotonBlasts.Add(PhotonBlast.MyllaAndYoulla);
          }
          else
          {
            p_mag.Name = MagName.Rudra;
            p_mag.PhotonBlasts.Add(PhotonBlast.Leilla);
          }
          break;
        case Character.RangerMale:
        case Character.RangerFemale:
          if (p_mag.PowLevel > p_mag.DexLevel && p_mag.PowLevel > p_mag.MindLevel)
          {
            p_mag.Name = MagName.Surya;
            p_mag.PhotonBlasts.Add(PhotonBlast.Golla);
          }
          else if (p_mag.DexLevel > p_mag.PowLevel && p_mag.DexLevel > p_mag.MindLevel)
          {
            p_mag.Name = MagName.Mitra;
            p_mag.PhotonBlasts.Add(PhotonBlast.Pilla);
          }
          else if (p_mag.MindLevel > p_mag.PowLevel && p_mag.MindLevel > p_mag.DexLevel)
          {
            p_mag.Name = MagName.Tapas;
            p_mag.PhotonBlasts.Add(PhotonBlast.MyllaAndYoulla);
          }
          else
          {
            p_mag.Name = MagName.Mitra;
            p_mag.PhotonBlasts.Add(PhotonBlast.Leilla);
          }
          break;
        case Character.ForceMale:
        case Character.ForceFemale:
          if (p_mag.PowLevel > p_mag.DexLevel && p_mag.PowLevel > p_mag.MindLevel)
          {
            p_mag.Name = MagName.Sumba;
            p_mag.PhotonBlasts.Add(PhotonBlast.Golla);
          }
          else if (p_mag.DexLevel > p_mag.PowLevel && p_mag.DexLevel > p_mag.MindLevel)
          {
            p_mag.Name = MagName.Ashvinau;
            p_mag.PhotonBlasts.Add(PhotonBlast.Pilla);
          }
          else if (p_mag.MindLevel > p_mag.PowLevel && p_mag.MindLevel > p_mag.DexLevel)
          {
            p_mag.Name = MagName.Namuci;
            p_mag.PhotonBlasts.Add(PhotonBlast.MyllaAndYoulla);
          }
          else
          {
            p_mag.Name = MagName.Namuci;
            p_mag.PhotonBlasts.Add(PhotonBlast.MyllaAndYoulla);
          }
          break;
      }
    }

    private static void MagChangeThree(ref Mag p_mag, Character p_character, SectionId p_sectionId)
    {
      switch (p_sectionId)
      {
        case SectionId.Viridia:
        case SectionId.Skyly:
        case SectionId.Purplenum:
        case SectionId.Redria:
        case SectionId.Yellowboze:
          switch (p_character)
          {
            case Character.HunterMale:
            case Character.HunterFemale:
              if (p_mag.PowLevel > p_mag.DexLevel && p_mag.PowLevel > p_mag.MindLevel)
              {
                // POW is First, look for second
                if (p_mag.DexLevel >= p_mag.MindLevel)
                  p_mag.Name = MagName.Varaha;
                else
                  p_mag.Name = MagName.Bhirava;
              }
              else if (p_mag.DexLevel > p_mag.PowLevel && p_mag.DexLevel > p_mag.MindLevel)
              {
                // Dex is First, look for second
                if (p_mag.MindLevel >= p_mag.PowLevel)
                  p_mag.Name = MagName.Nandin;
                else
                  p_mag.Name = MagName.Ila;
              }
              else if (p_mag.MindLevel > p_mag.PowLevel && p_mag.MindLevel > p_mag.DexLevel)
              {
                // Mind is First, look for second
                if (p_mag.PowLevel >= p_mag.DexLevel)
                  p_mag.Name = MagName.Kabanda;
                else
                  p_mag.Name = MagName.Ushasu;
              }
              else
              {
                // Tie of Pow/Dex/Mind, look for second
                if (p_mag.DexLevel >= p_mag.MindLevel)
                  p_mag.Name = MagName.Varaha;
                else
                  p_mag.Name = MagName.Bhirava;
              }
              break;
            case Character.RangerMale:
            case Character.RangerFemale:
              if (p_mag.PowLevel > p_mag.DexLevel && p_mag.PowLevel > p_mag.MindLevel)
              {
                if (p_mag.DexLevel >= p_mag.MindLevel)
                  p_mag.Name = MagName.Kama;
                else
                  p_mag.Name = MagName.Bhirava;
              }
              else if (p_mag.DexLevel > p_mag.PowLevel && p_mag.DexLevel > p_mag.MindLevel)
              {
                if (p_mag.MindLevel >= p_mag.PowLevel)
                  p_mag.Name = MagName.Kama;
                else
                  p_mag.Name = MagName.Bhirava;
              }
              else if (p_mag.MindLevel > p_mag.PowLevel && p_mag.MindLevel > p_mag.DexLevel)
              {
                if (p_mag.PowLevel >= p_mag.DexLevel)
                  p_mag.Name = MagName.Varaha;
                else
                  p_mag.Name = MagName.Asperus;
              }
              else
              {
                if (p_mag.MindLevel >= p_mag.PowLevel)
                  p_mag.Name = MagName.Kama;
                else
                  p_mag.Name = MagName.Bhirava;
              }
              break;
            case Character.ForceMale:
            case Character.ForceFemale:
              if (p_mag.PowLevel > p_mag.DexLevel && p_mag.PowLevel > p_mag.MindLevel)
              {
                if (p_mag.DefLevel >= 45)
                  p_mag.Name = MagName.Andhaka; // special def mag for Force
                else
                  if (p_mag.DexLevel >= p_mag.MindLevel)
                    p_mag.Name = MagName.Naraka;
                  else
                    p_mag.Name = MagName.Ravana;
              }
              else if (p_mag.DexLevel > p_mag.PowLevel && p_mag.DexLevel > p_mag.MindLevel)
              {
                if (p_mag.DefLevel >= 45)
                  p_mag.Name = MagName.Bana; // special def mag for Force
                else
                  if (p_mag.MindLevel >= p_mag.PowLevel)
                    p_mag.Name = MagName.Sita;
                  else
                    p_mag.Name = MagName.Ribhava;
              }
              else if (p_mag.MindLevel > p_mag.PowLevel && p_mag.MindLevel > p_mag.DexLevel)
              {
                if (p_mag.DefLevel >= 45)
                  p_mag.Name = MagName.Bana; // special def mag for Force
                else
                  if (p_mag.PowLevel >= p_mag.DexLevel)
                    p_mag.Name = MagName.Naga;
                  else
                    p_mag.Name = MagName.Kabanda;
              }
              else
              {
                if (p_mag.DefLevel >= 45)
                  p_mag.Name = MagName.Bana; // special def mag for Force
                else
                  if (p_mag.PowLevel >= p_mag.DexLevel)
                    p_mag.Name = MagName.Naga;
                  else
                    p_mag.Name = MagName.Kabanda;
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
          switch (p_character)
          {
            case Character.HunterMale:
            case Character.HunterFemale:
              if (p_mag.PowLevel > p_mag.DexLevel && p_mag.PowLevel > p_mag.MindLevel)
              {
                // POW is First, look for second
                if (p_mag.DexLevel >= p_mag.MindLevel)
                  p_mag.Name = MagName.Kama;
                else
                  p_mag.Name = MagName.Asperus;
              }
              else if (p_mag.DexLevel > p_mag.PowLevel && p_mag.DexLevel > p_mag.MindLevel)
              {
                // Dex is First, look for second
                if (p_mag.MindLevel >= p_mag.PowLevel)
                  p_mag.Name = MagName.Yaksa;
                else
                  p_mag.Name = MagName.Garuda;
              }
              else if (p_mag.MindLevel > p_mag.PowLevel && p_mag.MindLevel > p_mag.DexLevel)
              {
                // Mind is First, look for second
                if (p_mag.PowLevel >= p_mag.DexLevel)
                  p_mag.Name = MagName.Bana;
                else
                  p_mag.Name = MagName.Soma;
              }
              else
              {
                // Tie of Pow/Dex/Mind, look for second
                if (p_mag.DexLevel >= p_mag.MindLevel)
                  p_mag.Name = MagName.Kama;
                else
                  p_mag.Name = MagName.Asperus;
              }
              break;
            case Character.RangerMale:
            case Character.RangerFemale:
              if (p_mag.PowLevel > p_mag.DexLevel && p_mag.PowLevel > p_mag.MindLevel)
              {
                if (p_mag.DexLevel >= p_mag.MindLevel)
                  p_mag.Name = MagName.Madhu;
                else
                  p_mag.Name = MagName.Kaitabha;
              }
              else if (p_mag.DexLevel > p_mag.PowLevel && p_mag.DexLevel > p_mag.MindLevel)
              {
                if (p_mag.MindLevel >= p_mag.PowLevel)
                  p_mag.Name = MagName.Varaha;
                else
                  p_mag.Name = MagName.Kaitabha;
              }
              else if (p_mag.MindLevel > p_mag.PowLevel && p_mag.MindLevel > p_mag.DexLevel)
              {
                if (p_mag.PowLevel >= p_mag.DexLevel)
                  p_mag.Name = MagName.Kabanda;
                else
                  p_mag.Name = MagName.Durga;
              }
              else
              {
                if (p_mag.MindLevel >= p_mag.PowLevel)
                  p_mag.Name = MagName.Varaha;
                else
                  p_mag.Name = MagName.Kaitabha;
              }
              break;
            case Character.ForceMale:
            case Character.ForceFemale:
              if (p_mag.PowLevel > p_mag.DexLevel && p_mag.PowLevel > p_mag.MindLevel)
              {
                if (p_mag.DefLevel >= 45)
                  p_mag.Name = MagName.Andhaka; // special def mag for Force. Perhaps Pow > Dex + Mind
                else
                  if (p_mag.DexLevel >= p_mag.MindLevel)
                    p_mag.Name = MagName.Marica;
                  else
                    p_mag.Name = MagName.Naga;
              }
              else if (p_mag.DexLevel > p_mag.PowLevel && p_mag.DexLevel > p_mag.MindLevel)
              {
                if (p_mag.DefLevel >= 45)
                  p_mag.Name = MagName.Bana; // special def mag for Force. Perhaps Dex > Pow + Mind
                else
                  if (p_mag.MindLevel >= p_mag.PowLevel)
                    p_mag.Name = MagName.Bhirava;
                  else
                    p_mag.Name = MagName.Garuda;
              }
              else if (p_mag.MindLevel > p_mag.PowLevel && p_mag.MindLevel > p_mag.DexLevel)
              {
                if (p_mag.DefLevel >= 45)
                  p_mag.Name = MagName.Bana; // special def mag for Force. Perhaps Mind > Pow + Dex
                else
                  if (p_mag.PowLevel >= p_mag.DexLevel)
                    p_mag.Name = MagName.Kumara;
                  else
                    p_mag.Name = MagName.Ila;
              }
              else
              {
                if (p_mag.DefLevel >= 45)
                  p_mag.Name = MagName.Bana; // special def mag for Force. Perhaps Mind > Pow + Dex
                else
                  if (p_mag.PowLevel >= p_mag.DexLevel)
                    p_mag.Name = MagName.Kumara;
                  else
                    p_mag.Name = MagName.Ila;
              }
              break;
            default:
              break;
          }
          break;
      }

      GetLastPhotonBlast(ref p_mag);

      if(p_mag.Level > 99)
        MagChangeEpic(ref p_mag, p_character, p_sectionId);
    }

    private static void MagChangeEpic(ref Mag p_mag, Character p_character, SectionId p_sectionId)
    {
      switch (p_sectionId)
      {
        case SectionId.Skyly:
        case SectionId.Yellowboze:
        case SectionId.Pinkal:
          if ((p_mag.DefLevel + p_mag.PowLevel) == (p_mag.DexLevel + p_mag.MindLevel))
            switch (p_character)
            {
              case Character.HunterMale:
                p_mag.Name = MagName.Rati;
                break;
              case Character.HunterFemale:
                p_mag.Name = MagName.Savitri;
                break;
              case Character.RangerMale:
                p_mag.Name = MagName.Pushan;
                break;
              case Character.RangerFemale:
                p_mag.Name = MagName.Diwari;
                break;
              case Character.ForceMale:
                p_mag.Name = MagName.Nidra;
                break;
              case Character.ForceFemale:
                p_mag.Name = MagName.Bhima;
                break;
            }
          break;
        case SectionId.Bluefull:
        case SectionId.Viridia:
        case SectionId.Whitill:
        case SectionId.Redria:
          if ((p_mag.DefLevel + p_mag.DexLevel) == (p_mag.PowLevel + p_mag.MindLevel))
            switch (p_character)
            {
              case Character.HunterMale:
                p_mag.Name = MagName.Deva;
                break;
              case Character.HunterFemale:
                p_mag.Name = MagName.Savitri;
                break;
              case Character.RangerMale:
                p_mag.Name = MagName.Pushan;
                break;
              case Character.RangerFemale:
                p_mag.Name = MagName.Rukmin;
                break;
              case Character.ForceMale:
                p_mag.Name = MagName.Nidra;
                break;
              case Character.ForceFemale:
                p_mag.Name = MagName.Sato;
                break;
            }
          break;
        case SectionId.Oran:
        case SectionId.Greennill:
        case SectionId.Purplenum:
          if ((p_mag.DefLevel + p_mag.MindLevel) == (p_mag.DexLevel + p_mag.PowLevel))
            switch (p_character)
            {
              case Character.HunterMale:
                p_mag.Name = MagName.Rati;
                break;
              case Character.HunterFemale:
                p_mag.Name = MagName.Savitri;
                break;
              case Character.RangerMale:
                p_mag.Name = MagName.Pushan;
                break;
              case Character.RangerFemale:
                p_mag.Name = MagName.Rukmin;
                break;
              case Character.ForceMale:
                p_mag.Name = MagName.Nidra;
                break;
              case Character.ForceFemale:
                p_mag.Name = MagName.Bhima;
                break;
            }
          break;
      }
    }

    private static void GetLastPhotonBlast(ref Mag p_mag)
    {
      if(p_mag.PhotonBlasts.Count == 2)
        switch (p_mag.Name)
        {
          case MagName.Asperus:
          case MagName.Andhaka:
          case MagName.Soma:
          case MagName.Durga:
          case MagName.Nandin:
          case MagName.Bana:
            CheckPhotonBlast(ref p_mag, PhotonBlast.Estlla);
            break;
          case MagName.Ribhava:
          case MagName.Ravana:
            CheckPhotonBlast(ref p_mag, PhotonBlast.Farlla);
            break;
          case MagName.Ushasu:
          case MagName.Varaha:
          case MagName.Kumara:
          case MagName.Yaksa:
          case MagName.Naraka:
            CheckPhotonBlast(ref p_mag, PhotonBlast.Golla);
            break;
          case MagName.Kaitabha:
          case MagName.Ila:
          case MagName.Kabanda:
          case MagName.Naga:
          case MagName.Madhu:
            CheckPhotonBlast(ref p_mag, PhotonBlast.MyllaAndYoulla);
            break;
          case MagName.Kama:
          case MagName.Bhirava:
          case MagName.Garuda:
          case MagName.Sita:
          case MagName.Marica:
            CheckPhotonBlast(ref p_mag, PhotonBlast.Pilla);
            break;
        }
    }

    private static void CheckPhotonBlast(ref Mag p_mag, PhotonBlast p_photonBlast)
    {
      bool flag = false;

      foreach (PhotonBlast pb in p_mag.PhotonBlasts)
        if (pb != p_photonBlast)
          flag = true;

      if (flag)
        p_mag.PhotonBlasts.Add(p_photonBlast);
    }

    private static void CheckCosts(ref Mag p_mag, Item p_item)
    {
      switch (p_item)
      {
        case Item.Monomate:
          p_mag.Meseta += 50;
          break;
        case Item.Dimate:
          p_mag.Meseta += 300;
          break;
        case Item.Trimate:
          p_mag.Meseta += 2000;
          break;
        case Item.Monofluid:
          p_mag.Meseta += 100;
          break;
        case Item.Difluid:
          p_mag.Meseta += 500;
          break;
        case Item.Trifluid:
          p_mag.Meseta += 3600;
          break;
        case Item.Antidote:
          p_mag.Meseta += 60;
          break;
        case Item.Antiparalysis:
          p_mag.Meseta += 60;
          break;
        case Item.SolAtomizer:
          p_mag.Meseta += 300;
          break;
        case Item.MoonAtomizer:
          p_mag.Meseta += 500;
          break;
        case Item.StarAtomizer:
          p_mag.Meseta += 5000;
          break;
        default:
          break;
      }
    }
  }
}
