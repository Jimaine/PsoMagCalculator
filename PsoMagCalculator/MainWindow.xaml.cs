using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    int listCount = 0;
    int undo = -1;
    Mag mag = new Mag();
    List<Mag> mags = new List<Mag>();

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
      lblDef.Content = mag.DefLevel;
      lblPow.Content = mag.PowLevel;
      lblDex.Content = mag.DexLevel;
      lblMind.Content = mag.MindLevel;

      barDef.Value = mag.DefValue;
      barPow.Value = mag.PowValue;
      barDex.Value = mag.DexValue;
      barMind.Value = mag.MindValue;

      lblMagName.Content = mag.Name.ToString();
      lblIq.Content = String.Format("IQ: {0}", mag.IQ);
      lblSync.Content = String.Format("Sync: {0}", mag.Sync);
      lblMagLevel.Content = String.Format("Level: {0}", mag.Level);
      lblMeseta.Content = String.Format("{0} Meseta", mag.Meseta);
      imgMag.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/Mags/" + mag.Name.ToString() + ".gif");

      btnMonomate.ToolTip = Calculations.GetTooltip(Item.Monomate, mag.Name);
      btnDimate.ToolTip = Calculations.GetTooltip(Item.Dimate, mag.Name);
      btnTrimate.ToolTip = Calculations.GetTooltip(Item.Trimate, mag.Name);
      btnMonofluid.ToolTip = Calculations.GetTooltip(Item.Monofluid, mag.Name);
      btnDifluid.ToolTip = Calculations.GetTooltip(Item.Difluid, mag.Name);
      btnTrifluid.ToolTip = Calculations.GetTooltip(Item.Trifluid, mag.Name);
      btnAntidote.ToolTip = Calculations.GetTooltip(Item.Antidote, mag.Name);
      btnAntiparalysis.ToolTip = Calculations.GetTooltip(Item.Antiparalysis, mag.Name);
      btnSolAtomizer.ToolTip = Calculations.GetTooltip(Item.SolAtomizer, mag.Name);
      btnMoonAtomizer.ToolTip = Calculations.GetTooltip(Item.MoonAtomizer, mag.Name);
      btnStarAtomizer.ToolTip = Calculations.GetTooltip(Item.StarAtomizer, mag.Name);

      switch (mag.PhotonBlasts.Count)
      {
        case 0:
          imgPhotonOne.Source = null;
          imgPhotonTwo.Source = null;
          imgPhotonThree.Source = null;
          break;
        case 1:
          imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + mag.PhotonBlasts[0].ToString() + ".png");
          imgPhotonTwo.Source = null;
          imgPhotonThree.Source = null;
          break;
        case 2:
          imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + mag.PhotonBlasts[0].ToString() + ".png");
          imgPhotonTwo.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + mag.PhotonBlasts[1].ToString() + ".png");
          imgPhotonThree.Source = null;
          break;
        case 3:
          imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + mag.PhotonBlasts[0].ToString() + ".png");
          imgPhotonTwo.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + mag.PhotonBlasts[1].ToString() + ".png");
          imgPhotonThree.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + mag.PhotonBlasts[2].ToString() + ".png");
          break;
        default:
          break;
      }
    }

    private void AddToListBox(Item p_item)
    {
      listCount++;

      ListBoxItem lbi = new ListBoxItem();
      lbi.Content = "   " + listCount + " " + p_item.ToString();
      ListHistory.Items.Add(lbi);

      if (listCount % 3 == 0)
      {
        ListBoxItem lbiEmpty = new ListBoxItem();
        lbiEmpty.Content = "Zyklus " + ((listCount / 3) + 1);
        ListHistory.Items.Add(lbiEmpty);

        Mag testMag = new Mag();
        testMag.Level = ((listCount / 3) + 1);
        mags.Add(testMag);
      }
    }

    private void AddToListBox()
    {
      ListBoxItem lbiEmpty = new ListBoxItem();
      lbiEmpty.Content = "Zyklus 1";
      mags.Clear();
      mags.Add(new Mag());
      ListHistory.Items.Add(lbiEmpty);
    }

    private void btnMonomate_Click(object sender, RoutedEventArgs e)
    {
      if (mag.Level < 200)
      {
        CheckUndo();
        Calculations.Recalculate(ref mag, Item.Monomate, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Monomate);
        ShowMag();
      }
    }

    private void btnDimate_Click(object sender, RoutedEventArgs e)
    {
      if (mag.Level < 200)
      {
        Calculations.Recalculate(ref mag, Item.Dimate, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Dimate);
        ShowMag();
      }
    }

    private void btnTrimate_Click(object sender, RoutedEventArgs e)
    {
      if (mag.Level < 200)
      {
        Calculations.Recalculate(ref mag, Item.Trimate, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Trimate);
        ShowMag();
      }
    }

    private void btnMonofluid_Click(object sender, RoutedEventArgs e)
    {
      if (mag.Level < 200)
      {
        Calculations.Recalculate(ref mag, Item.Monofluid, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Monofluid);
        ShowMag();
      }
    }

    private void btnDifluid_Click(object sender, RoutedEventArgs e)
    {
      if (mag.Level < 200)
      {
        Calculations.Recalculate(ref mag, Item.Difluid, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Difluid);
        ShowMag();
      }
    }

    private void btnTrifluid_Click(object sender, RoutedEventArgs e)
    {
      if (mag.Level < 200)
      {
        Calculations.Recalculate(ref mag, Item.Trifluid, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Trifluid);
        ShowMag();
      }
    }

    private void btnAntidote_Click(object sender, RoutedEventArgs e)
    {
      if (mag.Level < 200)
      {
        Calculations.Recalculate(ref mag, Item.Antidote, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Antidote);
        ShowMag();
      }
    }

    private void btnAntiparalysis_Click(object sender, RoutedEventArgs e)
    {
      if (mag.Level < 200)
      {
        Calculations.Recalculate(ref mag, Item.Antiparalysis, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.Antiparalysis);
        ShowMag();
      }
    }

    private void btnSolAtomizer_Click(object sender, RoutedEventArgs e)
    {
      if (mag.Level < 200)
      {
        Calculations.Recalculate(ref mag, Item.SolAtomizer, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.SolAtomizer);
        ShowMag();
      }
    }

    private void btnMoonAtomizer_Click(object sender, RoutedEventArgs e)
    {
      if (mag.Level < 200)
      {
        Calculations.Recalculate(ref mag, Item.MoonAtomizer, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.MoonAtomizer);
        ShowMag();
      }
    }

    private void btnStarAtomizer_Click(object sender, RoutedEventArgs e)
    {
      if (mag.Level < 200)
      {
        Calculations.Recalculate(ref mag, Item.StarAtomizer, (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
        AddToListBox(Item.StarAtomizer);
        ShowMag();
      }
    }

    private void btnReset_Click(object sender, RoutedEventArgs e)
    {
      if (MessageBox.Show("Do you really want to delete this Mag?", "Deleting Mag", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
      {
        mag = new Mag();
        ShowMag();
        ListHistory.Items.Clear();
        AddToListBox();
        listCount = 0;
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

      if(lb.SelectedItems.Count == 1)
      {
        ListBoxItem lbi = (ListBoxItem)lb.SelectedItem;
        if (lbi.Content.ToString().Contains("Zyklus"))
        {
          int zyklus = Convert.ToInt32(lbi.Content.ToString().Substring(7));
          mag = mags[zyklus - 1];
          undo = zyklus;
        }
      }
    }

    private void CheckUndo()
    {
      if (undo > -1)
      {


        undo = -1;
      }
    }
  }
}
