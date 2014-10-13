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
    int m_ListCount = 0;
    int m_HistoryBack = -1;
    Mag m_MainMag = new Mag();
    List<Mag> m_MagsInHistory = new List<Mag>();
    Dictionary<Button, Item> m_Buttons = new Dictionary<Button, Item>();

    public MainWindow()
    {
      InitializeComponent();
      ShowMag();
      AddToListBox();

      cmbCharakter.ItemsSource = Enum.GetValues(typeof(Character)).Cast<Character>();
      cmbSectionId.ItemsSource = Enum.GetValues(typeof(SectionId)).Cast<SectionId>();

      imgPhotonOne.Source = null;
      imgPhotonTwo.Source = null;
      imgPhotonThree.Source = null;

      InitializeButtonDictionary();
    }

    private void ShowMag()
    {
      lblDef.Content = m_MainMag.DefLevel;
      lblPow.Content = m_MainMag.PowLevel;
      lblDex.Content = m_MainMag.DexLevel;
      lblMind.Content = m_MainMag.MindLevel;

      barDef.Value = m_MainMag.DefValue;
      barPow.Value = m_MainMag.PowValue;
      barDex.Value = m_MainMag.DexValue;
      barMind.Value = m_MainMag.MindValue;

      lblMagName.Content = m_MainMag.Name.ToString();
      lblIq.Content = String.Format("IQ: {0}", m_MainMag.IQ);
      lblSync.Content = String.Format("Sync: {0}", m_MainMag.Sync);
      lblMagLevel.Content = String.Format("Level: {0}", m_MainMag.Level);
      lblMeseta.Content = String.Format("{0} Meseta", m_MainMag.Meseta);
      imgMag.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/Mags/" + m_MainMag.Name.ToString() + ".gif");

      GetButtonTooltips();
      SetPhotonBlasts();
    }

    private void GetButtonTooltips()
    {
      btnMonomate.ToolTip = Calculations.GetTooltip(Item.Monomate, m_MainMag.Name);
      btnDimate.ToolTip = Calculations.GetTooltip(Item.Dimate, m_MainMag.Name);
      btnTrimate.ToolTip = Calculations.GetTooltip(Item.Trimate, m_MainMag.Name);
      btnMonofluid.ToolTip = Calculations.GetTooltip(Item.Monofluid, m_MainMag.Name);
      btnDifluid.ToolTip = Calculations.GetTooltip(Item.Difluid, m_MainMag.Name);
      btnTrifluid.ToolTip = Calculations.GetTooltip(Item.Trifluid, m_MainMag.Name);
      btnAntidote.ToolTip = Calculations.GetTooltip(Item.Antidote, m_MainMag.Name);
      btnAntiparalysis.ToolTip = Calculations.GetTooltip(Item.Antiparalysis, m_MainMag.Name);
      btnSolAtomizer.ToolTip = Calculations.GetTooltip(Item.SolAtomizer, m_MainMag.Name);
      btnMoonAtomizer.ToolTip = Calculations.GetTooltip(Item.MoonAtomizer, m_MainMag.Name);
      btnStarAtomizer.ToolTip = Calculations.GetTooltip(Item.StarAtomizer, m_MainMag.Name);
    }

    private void SetPhotonBlasts()
    {
      switch (m_MainMag.PhotonBlasts.Count)
      {
        case 0:
          imgPhotonOne.Source = null;
          imgPhotonTwo.Source = null;
          imgPhotonThree.Source = null;
          break;
        case 1:
          imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + m_MainMag.PhotonBlasts[0].ToString() + ".png");
          imgPhotonTwo.Source = null;
          imgPhotonThree.Source = null;
          break;
        case 2:
          imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + m_MainMag.PhotonBlasts[0].ToString() + ".png");
          imgPhotonTwo.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + m_MainMag.PhotonBlasts[1].ToString() + ".png");
          imgPhotonThree.Source = null;
          break;
        case 3:
          imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + m_MainMag.PhotonBlasts[0].ToString() + ".png");
          imgPhotonTwo.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + m_MainMag.PhotonBlasts[1].ToString() + ".png");
          imgPhotonThree.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + m_MainMag.PhotonBlasts[2].ToString() + ".png");
          break;
        default:
          break;
      }
    }

    private void InitializeButtonDictionary()
    {
      m_Buttons.Add(btnMonomate, Item.Monomate);
      m_Buttons.Add(btnDimate, Item.Dimate);
      m_Buttons.Add(btnTrimate, Item.Trimate);
      m_Buttons.Add(btnMonofluid, Item.Monofluid);
      m_Buttons.Add(btnDifluid, Item.Difluid);
      m_Buttons.Add(btnTrifluid, Item.Trifluid);
      m_Buttons.Add(btnAntidote, Item.Antidote);
      m_Buttons.Add(btnAntiparalysis, Item.Antiparalysis);
      m_Buttons.Add(btnSolAtomizer, Item.SolAtomizer);
      m_Buttons.Add(btnMoonAtomizer, Item.MoonAtomizer);
      m_Buttons.Add(btnStarAtomizer, Item.StarAtomizer);
    }

    private void AddToListBox()
    {
      ListBoxItem lbiEmpty = new ListBoxItem();
      lbiEmpty.Content = "Zyklus 1";
      m_MagsInHistory.Clear();
      m_MagsInHistory.Add(new Mag());
      ListHistory.Items.Add(lbiEmpty);
    }

    private void AddToListBox(Item p_item)
    {
      m_ListCount++;

      ListBoxItem lbi = new ListBoxItem();
      lbi.Content = String.Format("   {0} {1}", m_ListCount, p_item.ToString());
      ListHistory.Items.Add(lbi);

      if (m_ListCount % 3 == 0)
      {
        ListBoxItem lbiEmpty = new ListBoxItem();
        lbiEmpty.Content = String.Format("Zyklus {0}", ((m_ListCount / 3) + 1));
        ListHistory.Items.Add(lbiEmpty);
        m_MagsInHistory.Add(GenericCopy<Mag>.DeepCopy(m_MainMag));
      }
    }

    private void btnMagFeed_Click(object sender, RoutedEventArgs e)
    {
      if (m_MainMag.Level < 200)
      {
        CheckHistoryBack();
        Button button = (Button)sender;
        Calculations.Recalculate(m_MainMag, m_Buttons[button], (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(m_Buttons[button]);
        ShowMag();
      }
    }

    private void CheckHistoryBack()
    {
      if (m_HistoryBack > -1)
      {
        int lbIndes = m_HistoryBack * 4 - 3;

        for (int i = ListHistory.Items.Count - 1; i >= lbIndes; i--)
          ListHistory.Items.RemoveAt(i);

        ListHistory.Items.Refresh();
        m_ListCount = (m_HistoryBack - 1) * 3;
        m_HistoryBack = -1;
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

      if (sb.Length < 100)
        MessageBox.Show("The History was copy to Clipboard!\n\n" + sb.ToString(), "History", MessageBoxButton.OK, MessageBoxImage.Information);
      else
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
            m_MainMag = GenericCopy<Mag>.DeepCopy(m_MagsInHistory[zyklus - 1]);
            m_HistoryBack = zyklus;
          }
        }
      }
    }
  }
}
