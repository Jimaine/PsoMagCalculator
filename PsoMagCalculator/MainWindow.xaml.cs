using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PsoMagCalculator
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    int m_listCount = 0;
    int m_undo = -1;
    Mag m_mag = new Mag();
    List<Mag> m_mags = new List<Mag>();

    public MainWindow()
    {
      InitializeComponent();
      ShowMag();
      cmbCharakter.ItemsSource = Enum.GetValues(typeof(Character)).Cast<Character>();
      cmbSectionId.ItemsSource = Enum.GetValues(typeof(SectionId)).Cast<SectionId>();
      AddToListBox();
      imgPhotonOne.Source = null;
      imgPhotonTwo.Source = null;
      imgPhotonThree.Source = null;
    }

    private void ShowMag()
    {
      lblDef.Content = m_mag.DefLevel;
      lblPow.Content = m_mag.PowLevel;
      lblDex.Content = m_mag.DexLevel;
      lblMind.Content = m_mag.MindLevel;

      barDef.Value = m_mag.DefValue;
      barPow.Value = m_mag.PowValue;
      barDex.Value = m_mag.DexValue;
      barMind.Value = m_mag.MindValue;

      lblMagName.Content = m_mag.Name.ToString();
      lblIq.Content = String.Format("IQ: {0}", m_mag.IQ);
      lblSync.Content = String.Format("Sync: {0}", m_mag.Sync);
      lblMagLevel.Content = String.Format("Level: {0}", m_mag.Level);
      lblMeseta.Content = String.Format("{0} Meseta", m_mag.Meseta);
      imgMag.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/Mags/" + m_mag.Name.ToString() + ".gif");

      btnMonomate.ToolTip = Calculations.GetTooltip(Item.Monomate, m_mag.Name);
      btnDimate.ToolTip = Calculations.GetTooltip(Item.Dimate, m_mag.Name);
      btnTrimate.ToolTip = Calculations.GetTooltip(Item.Trimate, m_mag.Name);
      btnMonofluid.ToolTip = Calculations.GetTooltip(Item.Monofluid, m_mag.Name);
      btnDifluid.ToolTip = Calculations.GetTooltip(Item.Difluid, m_mag.Name);
      btnTrifluid.ToolTip = Calculations.GetTooltip(Item.Trifluid, m_mag.Name);
      btnAntidote.ToolTip = Calculations.GetTooltip(Item.Antidote, m_mag.Name);
      btnAntiparalysis.ToolTip = Calculations.GetTooltip(Item.Antiparalysis, m_mag.Name);
      btnSolAtomizer.ToolTip = Calculations.GetTooltip(Item.SolAtomizer, m_mag.Name);
      btnMoonAtomizer.ToolTip = Calculations.GetTooltip(Item.MoonAtomizer, m_mag.Name);
      btnStarAtomizer.ToolTip = Calculations.GetTooltip(Item.StarAtomizer, m_mag.Name);

      switch (m_mag.PhotonBlasts.Count)
      {
        case 0:
          imgPhotonOne.Source = null;
          imgPhotonTwo.Source = null;
          imgPhotonThree.Source = null;
          break;
        case 1:
          imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + m_mag.PhotonBlasts[0].ToString() + ".png");
          imgPhotonTwo.Source = null;
          imgPhotonThree.Source = null;
          break;
        case 2:
          imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + m_mag.PhotonBlasts[0].ToString() + ".png");
          imgPhotonTwo.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + m_mag.PhotonBlasts[1].ToString() + ".png");
          imgPhotonThree.Source = null;
          break;
        case 3:
          imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + m_mag.PhotonBlasts[0].ToString() + ".png");
          imgPhotonTwo.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + m_mag.PhotonBlasts[1].ToString() + ".png");
          imgPhotonThree.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + m_mag.PhotonBlasts[2].ToString() + ".png");
          break;
        default:
          break;
      }
    }

    private void AddToListBox(Item p_item)
    {
      m_listCount++;

      ListBoxItem lbi = new ListBoxItem();
      lbi.Content = "   " + m_listCount + " " + p_item.ToString();
      ListHistory.Items.Add(lbi);

      if (m_listCount % 3 == 0)
      {
        ListBoxItem lbiEmpty = new ListBoxItem();
        lbiEmpty.Content = "Zyklus " + ((m_listCount / 3) + 1);
        ListHistory.Items.Add(lbiEmpty);
        m_mags.Add(DeepCopy(m_mag));
      }
    }

    private void AddToListBox()
    {
      ListBoxItem lbiEmpty = new ListBoxItem();
      lbiEmpty.Content = "Zyklus 1";
      m_mags.Clear();
      m_mags.Add(new Mag());
      ListHistory.Items.Add(lbiEmpty);
    }

    private void btnMonomate_Click(object sender, RoutedEventArgs e)
    {
      if (m_mag.Level < 200)
      {
        CheckUndo();
        Calculations.Recalculate(ref m_mag, Item.Monomate, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Monomate);
        ShowMag();
      }
    }

    private void btnDimate_Click(object sender, RoutedEventArgs e)
    {
      if (m_mag.Level < 200)
      {
        CheckUndo();
        Calculations.Recalculate(ref m_mag, Item.Dimate, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Dimate);
        ShowMag();
      }
    }

    private void btnTrimate_Click(object sender, RoutedEventArgs e)
    {
      if (m_mag.Level < 200)
      {
        CheckUndo();
        Calculations.Recalculate(ref m_mag, Item.Trimate, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Trimate);
        ShowMag();
      }
    }

    private void btnMonofluid_Click(object sender, RoutedEventArgs e)
    {
      if (m_mag.Level < 200)
      {
        CheckUndo();
        Calculations.Recalculate(ref m_mag, Item.Monofluid, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Monofluid);
        ShowMag();
      }
    }

    private void btnDifluid_Click(object sender, RoutedEventArgs e)
    {
      if (m_mag.Level < 200)
      {
        CheckUndo();
        Calculations.Recalculate(ref m_mag, Item.Difluid, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Difluid);
        ShowMag();
      }
    }

    private void btnTrifluid_Click(object sender, RoutedEventArgs e)
    {
      if (m_mag.Level < 200)
      {
        CheckUndo();
        Calculations.Recalculate(ref m_mag, Item.Trifluid, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Trifluid);
        ShowMag();
      }
    }

    private void btnAntidote_Click(object sender, RoutedEventArgs e)
    {
      if (m_mag.Level < 200)
      {
        CheckUndo();
        Calculations.Recalculate(ref m_mag, Item.Antidote, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Antidote);
        ShowMag();
      }
    }

    private void btnAntiparalysis_Click(object sender, RoutedEventArgs e)
    {
      if (m_mag.Level < 200)
      {
        CheckUndo();
        Calculations.Recalculate(ref m_mag, Item.Antiparalysis, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Antiparalysis);
        ShowMag();
      }
    }

    private void btnSolAtomizer_Click(object sender, RoutedEventArgs e)
    {
      if (m_mag.Level < 200)
      {
        CheckUndo();
        Calculations.Recalculate(ref m_mag, Item.SolAtomizer, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.SolAtomizer);
        ShowMag();
      }
    }

    private void btnMoonAtomizer_Click(object sender, RoutedEventArgs e)
    {
      if (m_mag.Level < 200)
      {
        CheckUndo();
        Calculations.Recalculate(ref m_mag, Item.MoonAtomizer, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.MoonAtomizer);
        ShowMag();
      }
    }

    private void btnStarAtomizer_Click(object sender, RoutedEventArgs e)
    {
      if (m_mag.Level < 200)
      {
        CheckUndo();
        Calculations.Recalculate(ref m_mag, Item.StarAtomizer, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.StarAtomizer);
        ShowMag();
      }
    }

    private void btnReset_Click(object sender, RoutedEventArgs e)
    {
      if (MessageBox.Show("Do you really want to delete this Mag?", "Deleting Mag", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
      {
        m_mag = new Mag();
        ShowMag();
        ListHistory.Items.Clear();
        AddToListBox();
        m_listCount = 0;
      }
    }

    private void cmbSectionId_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      imgSectionId.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/SectionIds/" + cmbSectionId.SelectedItem + ".png");
    }

    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
      Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
      e.Handled = true;
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
      StringBuilder sb = new StringBuilder("Item History of your Mag\n\n");

      foreach (ListBoxItem item in ListHistory.Items)
        sb.Append(item.Content + "\n");

      Clipboard.SetText(sb.ToString());
      MessageBox.Show("The History was copy to Clipboard!\n\n" + sb.ToString().Substring(0, 100) + " ...", "History", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void ListHistory_MouseUp(object sender, MouseButtonEventArgs e)
    {
      ListBox lb = (ListBox)sender;

      if (lb.SelectedItems.Count == 1)
      {
        ListBoxItem lbi = (ListBoxItem)lb.SelectedItem;
        if (lbi.Content.ToString().Contains("Zyklus"))
        {
          int zyklus = Convert.ToInt32(lbi.Content.ToString().Substring(7));
          if (MessageBox.Show("The Mag will be set Back to Zyklus " + zyklus + ".\nDo you want to set your Mag back?", "Previous Mag", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
          {
            m_mag = DeepCopy(m_mags[zyklus - 1]);
            m_undo = zyklus;
          }
        }
      }
    }

    private void CheckUndo()
    {
      if (m_undo > -1)
      {
        int lbIndes = m_undo * 4 - 3;

        for (int i = ListHistory.Items.Count - 1; i >= lbIndes; i--)
          ListHistory.Items.RemoveAt(i);

        ListHistory.Items.Refresh();
        m_listCount = (m_undo - 1) * 3;
        m_undo = -1;
      }
    }

    private static Mag DeepCopy(Mag m_other)
    {
      using (MemoryStream ms = new MemoryStream())
      {
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(ms, m_other);
        ms.Position = 0;
        return (Mag)formatter.Deserialize(ms);
      }
    }
  }
}
