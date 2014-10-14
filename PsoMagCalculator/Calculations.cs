using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsoMagCalculator
{
  static class Calculations
  {
    private static MagFeedingTable m_Mft = new MagFeedingTable();
    
    /// <summary>
    /// Modifies the values of the Main Mag.
    /// </summary>
    /// <param name="p_mag">The Mag to modify.</param>
    /// <param name="p_item">The Item to feed the Mag</param>
    /// <param name="p_character">The character who feed the Mag</param>
    /// <param name="p_sectionId">The Id of the character who feed the Mag</param>
    public static void Recalculate(Mag p_mag, Item p_item, Character p_character, SectionId p_sectionId)
    {
      SetMag(p_mag, p_item);
      
      CheckLimits(p_mag);
      CheckLevel(p_mag, p_character, p_sectionId);
      CheckCosts(p_mag, p_item);
    }

    /// <summary>
    /// Return the Button's Tooltip as a string.
    /// </summary>
    /// <param name="p_item">The Item which represents the button</param>
    /// <param name="p_magName">The Name of the Main Mag</param>
    /// <returns>string</returns>
    public static string GetTooltip(Item p_item, MagName p_magName)
    {
      Mag tmpMag = new Mag();

      tmpMag.Name = p_magName;
      SetMag(tmpMag, p_item);

      return p_item.ToString() + "\n\n" + GetHoverText(tmpMag);
    }

    private static string GetHoverText(Mag p_mag)
    {
      return String.Format("IQ: {0}\nSync: {1}\nDef: {2}\nPow: {3}\nDex: {4}\nMind: {5}", p_mag.IQ, p_mag.Sync, p_mag.DefValue, p_mag.PowValue, p_mag.DexValue, p_mag.MindValue);
    }

    private static void SetMag(Mag p_mag, Item p_item)
    {
      switch (p_mag.Name)
      {
        case MagName.Mag:
          m_Mft.FeedingTables[0][p_item].AddToMag(p_mag);
          break;
        case MagName.Varuna:
        case MagName.Vritra:
        case MagName.Kalki:
          m_Mft.FeedingTables[1][p_item].AddToMag(p_mag);
          break;
        case MagName.Ashvinau:
        case MagName.Sumba:
        case MagName.Namuci:
        case MagName.Marutah:
        case MagName.Rudra:
          m_Mft.FeedingTables[2][p_item].AddToMag(p_mag);
          break;
        case MagName.Surya:
        case MagName.Tapas:
        case MagName.Mitra:
          m_Mft.FeedingTables[3][p_item].AddToMag(p_mag);
          break;
        case MagName.Asperus:
        case MagName.Vayu:
        case MagName.Varaha:
        case MagName.Ushasu:
        case MagName.Kama:
        case MagName.Kaitabha:
        case MagName.Kumara:
        case MagName.Bhirava:
          m_Mft.FeedingTables[4][p_item].AddToMag(p_mag);
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
          m_Mft.FeedingTables[5][p_item].AddToMag(p_mag);
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
          m_Mft.FeedingTables[6][p_item].AddToMag(p_mag);
          break;
        case MagName.Savitri:
        case MagName.Diwari:
        case MagName.Nidra:
          m_Mft.FeedingTables[7][p_item].AddToMag(p_mag);
          break;
      }
    }

    private static void CheckLimits(Mag p_mag)
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

    private static void CheckLevel(Mag p_mag, Character p_character, SectionId p_sectionId)
    {
      int levelUps = SetLevel(p_mag);

      // Mag Change only for non-epic
      if (p_mag.Name != MagName.Rukmin && p_mag.Name != MagName.Bhima && p_mag.Name != MagName.Nidra && p_mag.Name != MagName.Rukmin && p_mag.Name != MagName.Pushan && p_mag.Name != MagName.Savitri && p_mag.Name != MagName.Rati && p_mag.Name != MagName.Sato && p_mag.Name != MagName.Deva && p_mag.Name != MagName.Diwari)
        if (levelUps >= 1)
          for (int i = 0; i < levelUps; i++)
          {
            CheckMagChange(p_mag, p_character, p_sectionId);
          }
    }

    private static int SetLevel(Mag p_mag)
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

    private static void CheckMagChange(Mag p_mag, Character p_character, SectionId p_sectionId)
    {
      switch (p_mag.Level)
      {
        case 10:
        case 11:
        case 12:
        case 13:
          if (p_mag.Name == MagName.Mag)
            MagChangeOne(p_mag, p_character);
          break;
        case 35:
        case 36:
        case 37:
        case 38:
          if (p_mag.Name == MagName.Varuna || p_mag.Name == MagName.Kalki || p_mag.Name == MagName.Vritra)
            MagChangeTwo(p_mag, p_character);
          break;
        default:
          if (p_mag.Level >= 50 && (p_mag.Level % 5) == 0)
            MagChangeThree(p_mag, p_character, p_sectionId);
          break;
      }
    }

    private static void MagChangeOne(Mag p_mag, Character p_character)
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

    private static void MagChangeTwo(Mag p_mag, Character p_character)
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

    private static void MagChangeThree(Mag p_mag, Character p_character, SectionId p_sectionId)
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

      GetLastPhotonBlast(p_mag);

      if (p_mag.Level > 99)
        MagChangeEpic(p_mag, p_character, p_sectionId);
    }

    private static void GetLastPhotonBlast(Mag p_mag)
    {
      if (p_mag.PhotonBlasts.Count == 2)
        switch (p_mag.Name)
        {
          case MagName.Asperus:
          case MagName.Andhaka:
          case MagName.Soma:
          case MagName.Durga:
          case MagName.Nandin:
          case MagName.Bana:
            CheckPhotonBlast(p_mag, PhotonBlast.Estlla);
            break;
          case MagName.Ribhava:
          case MagName.Ravana:
            CheckPhotonBlast(p_mag, PhotonBlast.Farlla);
            break;
          case MagName.Ushasu:
          case MagName.Varaha:
          case MagName.Kumara:
          case MagName.Yaksa:
          case MagName.Naraka:
            CheckPhotonBlast(p_mag, PhotonBlast.Golla);
            break;
          case MagName.Kaitabha:
          case MagName.Ila:
          case MagName.Kabanda:
          case MagName.Naga:
          case MagName.Madhu:
            CheckPhotonBlast(p_mag, PhotonBlast.MyllaAndYoulla);
            break;
          case MagName.Kama:
          case MagName.Bhirava:
          case MagName.Garuda:
          case MagName.Sita:
          case MagName.Marica:
            CheckPhotonBlast(p_mag, PhotonBlast.Pilla);
            break;
        }
    }

    private static void CheckPhotonBlast(Mag p_mag, PhotonBlast p_photonBlast)
    {
      bool flag = false;

      foreach (PhotonBlast pb in p_mag.PhotonBlasts)
        if (pb != p_photonBlast)
          flag = true;

      if (flag)
        p_mag.PhotonBlasts.Add(p_photonBlast);
    }

    private static void MagChangeEpic(Mag p_mag, Character p_character, SectionId p_sectionId)
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

    private static void CheckCosts(Mag p_mag, Item p_item)
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
