using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using AzzyAIConfig.Properties;

using DataGrid = System.Windows.Controls.DataGrid;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.Forms.MessageBox;
using TextBox = System.Windows.Controls.TextBox;

namespace AzzyAIConfig
{
    /// <summary>
    /// Interaction logic for MainForm2.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel mainViewModel = new MainViewModel();

        public MainWindow()
        {
            this.InitializeComponent();

            this.LoadUiSettings();

            this.DataContext = this.mainViewModel;
        }

        private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
        {
            mainViewModel.SaveChanges();
        }

        private void QuitButton_OnClick(object sender, RoutedEventArgs e)
        {
            mainViewModel.Close();
        }
        private void DocumentationMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists("Documentation.pdf"))
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process {StartInfo = {FileName = "Documentation.pdf"}};
                p.Start();
            }
            else
            {
                MessageBox.Show("Documentation file could not be found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AboutMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            new AzzyAIAboutBox().ShowDialog();
        }

        private void RevertMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.mainViewModel.Revert();
        }

        private void ResetToDefaultsItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.mainViewModel.ResetToDefaults();
        }

        private void ImportHomSettingsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.mainViewModel.ImportHomunculusSettings();
        }

        private void ImportHomTacticsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.mainViewModel.ImportHomunculusTactics();
        }

        private void ExportHomSettingsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.mainViewModel.ExportHomunculusSettings();
        }

        private void ExportHomTacticsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.mainViewModel.ExportHomunculusTactics();
        }

        private void ImportMercSettingsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.mainViewModel.ImportMercenarySettings();
        }

        private void ImportMercTacticsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.mainViewModel.ImportMercenaryTactics();
        }

        private void ExportMercSettingsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.mainViewModel.ExportMercenarySettings();
        }

        private void ExportMercTacticsMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.mainViewModel.ExportMercenaryTactics();
        }

        private void HomType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.mainViewModel.UpdateShownHomOptions();
        }

        private void UIElement_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.mainViewModel.TextFilter = null;
            }
        }

        private void TabItem_OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.TabControl.SelectedItem != null && (this.TabControl.SelectedItem as TabItem).Visibility == Visibility.Collapsed)
            {
                this.TabControl.SelectedItem = this.TabControl.Items.Cast<TabItem>().First(t => t.Visibility == Visibility.Visible);
            }
        }

        private void DataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)e.OriginalSource;
            ConfigOption option = element.DataContext as ConfigOption;
            if (option == null)
            {
                return;
            }

            switch (option.Type)
            {
                case ConfigOption.ValueType.Boolean:
                    option.Value = !(bool)option.Value;
                    break;
                case ConfigOption.ValueType.Integer:
                    // todo: move to the textbox and select all text in ith
                    break;
                case ConfigOption.ValueType.Enumeration:
                    option.Value = option.EnumValues[(option.EnumValues.IndexOf(option.Value as Enum) + 1) % option.EnumValues.Count];
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ConfigGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            if (grid.SelectedItem == null)
            {
                grid.SelectedIndex = 0;
            }
        }

        private void ToggleButton_OnCheckChanged(object sender, RoutedEventArgs e)
        {
            this.mainViewModel.SaveEnabled = true;
            this.mainViewModel.RevertEnabled = true;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.mainViewModel.SaveEnabled = true;
            this.mainViewModel.RevertEnabled = true;
        }

        private void NumericBoxDownButton_OnClick(object sender, RoutedEventArgs e)
        {
            ConfigOption option = (ConfigOption)((RepeatButton)sender).DataContext;
            option.Value = ((int)option.Value) - 1;
        }

        private void NumericBoxUpButton_OnClick(object sender, RoutedEventArgs e)
        {
            ConfigOption option = (ConfigOption)((RepeatButton)sender).DataContext;
            option.Value = ((int)option.Value) + 1;
        }

        private void NumericBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ConfigOption option = (ConfigOption)textBox.DataContext;
            int change;
            switch (e.Key)
            {
                case Key.Up:
                    change = 1;
                    break;
                case Key.Down:
                    change = -1;
                    break;
                case Key.PageUp:
                    change = 10;
                    break;
                case Key.PageDown:
                    change = -10;
                    break;
                default:
                    return;
            }

            option.Value = (int)option.Value + change;
            textBox.CaretIndex = textBox.Text.Length;
            e.Handled = true;
        }

        private void NumericBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Any(c => !char.IsDigit(c)))
            {
                string sign = textBox.Text.StartsWith("-") ? "-" : string.Empty;
                textBox.Text = sign + new string(textBox.Text.Where(char.IsDigit).ToArray());
            }

            this.mainViewModel.SaveEnabled = true;
            this.mainViewModel.RevertEnabled = true;
        }

        private void NumericBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Any(c => c != '-' && !char.IsDigit(c)))
            {
                e.Handled = true;
            }
            else
            {
                this.mainViewModel.SaveEnabled = true;
                this.mainViewModel.RevertEnabled = true;
            }
        }

        private void LoadUiSettings()
        {
            this.Width = Settings.Default.Width;
            this.Height = Settings.Default.Height;
            this.HomCheckBox.IsChecked = Settings.Default.ShowHomunculus;
            this.MercCheckBox.IsChecked = Settings.Default.ShowMercenary;
            this.mainViewModel.SelectedHomunculusDisplayType = (HomunculusDisplayType)Settings.Default.HomunculusType;
            this.mainViewModel.SelectedSHomunculusDisplayType = (SHomunculusDisplayType)Settings.Default.SHomunculusType;

            // TODO: load the column widths from the grids
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            Settings.Default.Width = this.Width;
            Settings.Default.Height = this.Height;
            Settings.Default.ShowHomunculus = this.HomCheckBox.IsChecked ?? true;
            Settings.Default.ShowMercenary = this.MercCheckBox.IsChecked ?? true;
            Settings.Default.HomunculusType = (int)this.mainViewModel.SelectedHomunculusDisplayType;
            Settings.Default.SHomunculusType = (int)this.mainViewModel.SelectedSHomunculusDisplayType;

            // TODO: save the column widths from the grids

            Settings.Default.Save();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Settings.Default.Reset();
            this.LoadUiSettings();
        }

        private void ExtraOptionBox_OnTextInput(object sender, TextCompositionEventArgs e)
        {
            this.mainViewModel.SaveEnabled = true;
            this.mainViewModel.RevertEnabled = true;
        }
    }
}