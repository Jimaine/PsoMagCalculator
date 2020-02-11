using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace PsoMagCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private int listCount = 0;
        private int historyBack = -1;
        private Mag mainMag = new Mag();
        private List<Mag> magsInHistory = new List<Mag>();
        private Dictionary<Button, Item> buttons = new Dictionary<Button, Item>();

        /// <summary>
        /// Initialize the whole Grid.
        /// </summary>
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
            lblDef.Content = mainMag.DefLevel;
            lblPow.Content = mainMag.PowLevel;
            lblDex.Content = mainMag.DexLevel;
            lblMind.Content = mainMag.MindLevel;

            barDef.Value = mainMag.DefValue;
            barPow.Value = mainMag.PowValue;
            barDex.Value = mainMag.DexValue;
            barMind.Value = mainMag.MindValue;

            lblMagName.Content = mainMag.Name.ToString();
            lblIq.Content = String.Format("IQ: {0}", mainMag.IQ);
            lblSync.Content = String.Format("Sync: {0}", mainMag.Sync);
            lblMagLevel.Content = String.Format("Level: {0}", mainMag.Level);
            lblMeseta.Content = String.Format("{0} Meseta", mainMag.Meseta);
            imgMag.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/Mags/" + mainMag.Name.ToString() + ".gif");

            GetButtonTooltips();
            SetPhotonBlasts();
        }

        private void GetButtonTooltips()
        {
            btnMonomate.ToolTip = Calculations.GetTooltip(Item.Monomate, mainMag.Name);
            btnDimate.ToolTip = Calculations.GetTooltip(Item.Dimate, mainMag.Name);
            btnTrimate.ToolTip = Calculations.GetTooltip(Item.Trimate, mainMag.Name);
            btnMonofluid.ToolTip = Calculations.GetTooltip(Item.Monofluid, mainMag.Name);
            btnDifluid.ToolTip = Calculations.GetTooltip(Item.Difluid, mainMag.Name);
            btnTrifluid.ToolTip = Calculations.GetTooltip(Item.Trifluid, mainMag.Name);
            btnAntidote.ToolTip = Calculations.GetTooltip(Item.Antidote, mainMag.Name);
            btnAntiparalysis.ToolTip = Calculations.GetTooltip(Item.Antiparalysis, mainMag.Name);
            btnSolAtomizer.ToolTip = Calculations.GetTooltip(Item.SolAtomizer, mainMag.Name);
            btnMoonAtomizer.ToolTip = Calculations.GetTooltip(Item.MoonAtomizer, mainMag.Name);
            btnStarAtomizer.ToolTip = Calculations.GetTooltip(Item.StarAtomizer, mainMag.Name);
        }

        private void SetPhotonBlasts()
        {
            switch (mainMag.PhotonBlasts.Count)
            {
                case 0:
                    imgPhotonOne.Source = null;
                    imgPhotonTwo.Source = null;
                    imgPhotonThree.Source = null;
                    break;
                case 1:
                    imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + mainMag.PhotonBlasts[0].ToString() + ".png");
                    imgPhotonTwo.Source = null;
                    imgPhotonThree.Source = null;
                    break;
                case 2:
                    imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + mainMag.PhotonBlasts[0].ToString() + ".png");
                    imgPhotonTwo.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + mainMag.PhotonBlasts[1].ToString() + ".png");
                    imgPhotonThree.Source = null;
                    break;
                case 3:
                    imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + mainMag.PhotonBlasts[0].ToString() + ".png");
                    imgPhotonTwo.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + mainMag.PhotonBlasts[1].ToString() + ".png");
                    imgPhotonThree.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/PhotonBlasts/" + mainMag.PhotonBlasts[2].ToString() + ".png");
                    break;
                default:
                    break;
            }
        }

        private void InitializeButtonDictionary()
        {
            buttons.Add(btnMonomate, Item.Monomate);
            buttons.Add(btnDimate, Item.Dimate);
            buttons.Add(btnTrimate, Item.Trimate);
            buttons.Add(btnMonofluid, Item.Monofluid);
            buttons.Add(btnDifluid, Item.Difluid);
            buttons.Add(btnTrifluid, Item.Trifluid);
            buttons.Add(btnAntidote, Item.Antidote);
            buttons.Add(btnAntiparalysis, Item.Antiparalysis);
            buttons.Add(btnSolAtomizer, Item.SolAtomizer);
            buttons.Add(btnMoonAtomizer, Item.MoonAtomizer);
            buttons.Add(btnStarAtomizer, Item.StarAtomizer);
        }

        private void AddToListBox()
        {
            // Start value for the list.
            ListBoxItem lbiEmpty = new ListBoxItem();
            lbiEmpty.Content = "Zyklus 1";
            magsInHistory.Clear();
            magsInHistory.Add(new Mag());
            ListHistory.Items.Add(lbiEmpty);
        }

        private void AddToListBox(Item item)
        {
            listCount++;

            ListBoxItem lbi = new ListBoxItem();
            lbi.Content = String.Format("   {0} {1}", listCount, item.ToString());
            ListHistory.Items.Add(lbi);

            if (listCount % 3 == 0)
            {
                ListBoxItem lbiEmpty = new ListBoxItem();
                lbiEmpty.Content = String.Format("Zyklus {0}", ((listCount / 3) + 1));
                ListHistory.Items.Add(lbiEmpty);
                magsInHistory.Add(GenericCopy<Mag>.DeepCopy(mainMag));
            }
        }

        private void btnMagFeed_Click(object sender, RoutedEventArgs e)
        {
            if (mainMag.Level < 200)
            {
                CheckHistoryBack();
                Button button = (Button)sender;
                Calculations.Recalculate(mainMag, buttons[button], (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
                AddToListBox(buttons[button]);
                ShowMag();
            }
        }

        private void CheckHistoryBack()
        {
            if (historyBack > -1)
            {
                int lbIndes = historyBack * 4 - 3;

                for (int i = ListHistory.Items.Count - 1; i >= lbIndes; i--)
                    ListHistory.Items.RemoveAt(i);

                ListHistory.Items.Refresh();
                listCount = (historyBack - 1) * 3;
                historyBack = -1;
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
                        mainMag = GenericCopy<Mag>.DeepCopy(magsInHistory[zyklus - 1]);
                        historyBack = zyklus;
                    }
                }
            }
        }
    }
}
