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
    public partial class MainWindow : Window
    {
        private int listCount = 0;
        private Mag mainMag = new Mag();
        private readonly List<Mag> magsInHistory = new List<Mag>();
        private readonly Dictionary<Button, Item> buttons = new Dictionary<Button, Item>();

        /// <summary>
        /// Initialize the whole Grid.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            ShowMag();

            magsInHistory.Clear();

            cmbCharakter.ItemsSource = Enum.GetValues(typeof(Character)).Cast<Character>();
            cmbSectionId.ItemsSource = Enum.GetValues(typeof(SectionId)).Cast<SectionId>();

            imgPhotonOne.Source = null;
            imgPhotonTwo.Source = null;
            imgPhotonThree.Source = null;

            InitializeButtonDictionary();
        }

        private void MagFeedButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainMag.Level < 200)
            {
                var button = (Button)sender;
                AddToListBox(buttons[button]);
                Calculations.Recalculate(mainMag, buttons[button], (Character)cmbCharakter.SelectedItem, (SectionId)cmbSectionId.SelectedItem);
                ShowMag();
            }
        }

        private void SectionIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            imgSectionId.Source = (ImageSource)new ImageSourceConverter().ConvertFromString($"../../Images/SectionIds/{cmbSectionId.SelectedItem}.png");
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var stringBuilder = new StringBuilder("Item History of your Mag\n\n");
            string messageBoxText;

            foreach (ListBoxItem item in ListHistory.Items)
            {
                stringBuilder.Append($"{item.Content}\n");
            }

            Clipboard.SetText(stringBuilder.ToString());

            stringBuilder.Length = 100;
            messageBoxText = $"The History was copy to Clipboard!\n\n{stringBuilder}{(stringBuilder.Length == 100 ? " ..." : string.Empty)}";
            MessageBox.Show(messageBoxText, "History", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ListHistory_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var listBox = (ListBox)sender;

            if (listBox.SelectedItems.Count == 1)
            {
                var listBoxItem = (ListBoxItem)listBox.SelectedItem;

                if (listBoxItem.Content.ToString().Contains("Zyklus"))
                {
                    int zyklus = Convert.ToInt32(listBoxItem.Content.ToString().Substring(7));

                    if (MessageBox.Show($"The Mag will be set Back to Zyklus {zyklus}.\nDo you want to set your Mag back?", "Previous Mag", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        mainMag = GenericCopy<Mag>.DeepCopy(magsInHistory[zyklus - 1]);
                        ShowMag();
                        CheckHistoryBack(zyklus - 1);
                    }
                }
            }
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

            lblMagName.Content = mainMag.Name;
            lblIq.Content = $"IQ: {mainMag.IQ}";
            lblSync.Content = $"Sync: {mainMag.Sync}";
            lblMagLevel.Content = $"Level: {mainMag.Level}";
            lblMeseta.Content = $"{mainMag.Meseta} Meseta";
            imgMag.Source = (ImageSource)new ImageSourceConverter().ConvertFromString($"../../Images/Mags/{mainMag.Name}.gif");

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
                    imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString($"../../Images/PhotonBlasts/{mainMag.PhotonBlasts[0]}.png");
                    imgPhotonTwo.Source = null;
                    imgPhotonThree.Source = null;
                    break;
                case 2:
                    imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString($"../../Images/PhotonBlasts/{mainMag.PhotonBlasts[0]}.png");
                    imgPhotonTwo.Source = (ImageSource)new ImageSourceConverter().ConvertFromString($"../../Images/PhotonBlasts/{mainMag.PhotonBlasts[1]}.png");
                    imgPhotonThree.Source = null;
                    break;
                case 3:
                    imgPhotonOne.Source = (ImageSource)new ImageSourceConverter().ConvertFromString($"../../Images/PhotonBlasts/{mainMag.PhotonBlasts[0]}.png");
                    imgPhotonTwo.Source = (ImageSource)new ImageSourceConverter().ConvertFromString($"../../Images/PhotonBlasts/{mainMag.PhotonBlasts[1]}.png");
                    imgPhotonThree.Source = (ImageSource)new ImageSourceConverter().ConvertFromString($"../../Images/PhotonBlasts/{mainMag.PhotonBlasts[2]}.png");
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

        private void AddToListBox(Item item)
        {
            if (listCount % 3 == 0)
            {
                var listBoxItemEmpty = new ListBoxItem() { Content = $"Zyklus {((listCount / 3) + 1)}" };
                ListHistory.Items.Add(listBoxItemEmpty);
                magsInHistory.Add(GenericCopy<Mag>.DeepCopy(mainMag));
            }

            listCount++;

            var listBoxItem = new ListBoxItem() { Content = $"   {listCount}) {item}" };
            ListHistory.Items.Add(listBoxItem);
        }

        private void CheckHistoryBack(int historyBack)
        {
            if (historyBack > -1)
            {
                int lbIndes = historyBack * 4;

                for (int i = ListHistory.Items.Count - 1; i >= lbIndes; i--)
                {
                    ListHistory.Items.RemoveAt(i);
                }

                ListHistory.Items.Refresh();
                listCount = historyBack * 3;
            }
        }
    }
}
