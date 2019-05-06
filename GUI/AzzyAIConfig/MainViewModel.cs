using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using AzzyAIConfig.Annotations;
using MessageBox = System.Windows.Forms.MessageBox;

namespace AzzyAIConfig
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<ConfigOption> homConfOptionsList;
        private List<ConfigOption> mercConfOptionsList;
        private bool resetToDefaultsEnabled;
        private bool revertEnabled;
        private bool saveEnabled;
        private HomunculusDisplayType selectedHomunculusDisplayType = HomunculusDisplayType.All;
        private SHomunculusDisplayType selectedSHomunculusDisplayType = SHomunculusDisplayType.All;
        private ICollectionView shownHomConfOptionsList;
        private ICollectionView shownMercConfOptionsList;
        private ICollectionView showHomTacticsList;
        private ICollectionView shownMercTacticsList;
        private ICollectionView showHomPvpTacticsList;
        private ICollectionView shownMercPvpTacticsList;
        private string textFilter;
        private string selectedExtraDisplayType;
        private ExtraConfig selectedExtraOption;
        private List<ExtraConfig> extraConfigs;

        public MainViewModel()
        {
            this.HomConf = new HomConf("H_Config.lua");
            this.MercConf = new MerConf("M_Config.lua");
            this.UpdateShownMercOptions();
            H_Tactics.Load("H_Tactics.lua");
            M_Tactics.Load("M_Tactics.lua");

            PVP_Tact.Load("H_PVP_Tact.lua");
            M_PVP_Tact.Load("M_PVP_Tact.lua");

            this.ShownHomTacticsList = new CollectionView(H_Tactics.Tactics);
            this.ShownMercTacticsList = new CollectionView(M_Tactics.Tactics);

            this.ShownHomPvpTacticsList = new CollectionView(PVP_Tact.Tactics);
            this.ShownMercPvpTacticsList = new CollectionView(M_PVP_Tact.Tactics);

            this.ExtraConfigs = new List<ExtraConfig>
                {
                    new ExtraConfig("Homunculus", "H_Extra.lua"),
                    new ExtraConfig("Mercenary", "M_Extra.lua")
                };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public HomConf HomConf { get; set; }

        public List<ConfigOption> HomConfOptionsList
        {
            get
            {
                if (this.homConfOptionsList == null)
                {
                    this.homConfOptionsList = this.HomConf.GetType().GetProperties().Select(p => new ConfigOption(p, this.HomConf)).ToList();
                    foreach (ConfigOption configOption in this.homConfOptionsList)
                    {
                        configOption.PropertyChanged += this.ConfigOptionOnPropertyChanged;
                    }
                }

                return this.homConfOptionsList;
            }
        }

        public List<ExtraConfig> ExtraConfigs
        {
            get
            {
                return this.extraConfigs;
            }

            private set
            {
                if (this.extraConfigs != null)
                {
                    this.extraConfigs.ForEach(c => c.PropertyChanged -= this.ExtraConfig_OnPropertyChanged);
                }

                this.extraConfigs = value;


                if (this.extraConfigs != null)
                {
                    this.extraConfigs.ForEach(c => c.PropertyChanged += this.ExtraConfig_OnPropertyChanged);
                }
            }
        }

        private void ExtraConfig_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.SaveEnabled = true;
            this.RevertEnabled = true;
        }

        public MerConf MercConf { get; set; }

        public List<ConfigOption> MercConfOptionsList
        {
            get
            {
                if (this.mercConfOptionsList == null)
                {
                    this.mercConfOptionsList = this.MercConf.GetType().GetProperties().Select(p => new ConfigOption(p, this.MercConf)).ToList();
                    foreach (ConfigOption configOption in this.mercConfOptionsList)
                    {
                        configOption.PropertyChanged += this.ConfigOptionOnPropertyChanged;
                    }
                }

                return this.mercConfOptionsList;
            }
        }

        public bool ResetToDefaultsEnabled
        {
            get
            {
                return this.resetToDefaultsEnabled;
            }

            set
            {
                if (this.resetToDefaultsEnabled == value)
                {
                    return;
                }

                this.resetToDefaultsEnabled = value;
                this.OnPropertyChanged("ResetToDefaultsEnabled");
            }
        }

        public bool RevertEnabled
        {
            get
            {
                return this.revertEnabled;
            }

            set
            {
                if (this.revertEnabled == value)
                {
                    return;
                }

                this.revertEnabled = value;
                this.OnPropertyChanged("RevertEnabled");
            }
        }

        public bool SaveEnabled
        {
            get
            {
                return this.saveEnabled;
            }

            set
            {
                if (this.saveEnabled == value)
                {
                    return;
                }

                this.saveEnabled = value;
                this.OnPropertyChanged("SaveEnabled");
            }
        }

        public HomunculusDisplayType SelectedHomunculusDisplayType
        {
            get
            {
                return this.selectedHomunculusDisplayType;
            }

            set
            {
                if (this.selectedHomunculusDisplayType == value)
                {
                    return;
                }

                this.selectedHomunculusDisplayType = value;
                this.OnPropertyChanged("SelectedHomunculusDisplayType");
            }
        }

        public SHomunculusDisplayType SelectedSHomunculusDisplayType
        {
            get
            {
                return this.selectedSHomunculusDisplayType;
            }

            set
            {
                if (this.selectedSHomunculusDisplayType == value)
                {
                    return;
                }

                this.selectedSHomunculusDisplayType = value;
                this.OnPropertyChanged("SelectedSHomunculusDisplayType");
            }
        }

        public ICollectionView ShownHomConfOptionsList
        {
            get
            {
                return this.shownHomConfOptionsList;
            }

            set
            {
                this.shownHomConfOptionsList = value;
                this.OnPropertyChanged("ShownHomConfOptionsList");
            }
        }

        public ICollectionView ShownHomTacticsList
        {
            get
            {
                return this.showHomTacticsList;
            }

            set
            {
                this.showHomTacticsList = value;
                this.OnPropertyChanged("ShownHomTacticsList");
            }
        }

        public ICollectionView ShownHomPvpTacticsList
        {
            get
            {
                return this.showHomPvpTacticsList;
            }

            set
            {
                this.showHomPvpTacticsList = value;
                this.OnPropertyChanged("ShownHomPvpTacticsList");
            }
        }

        public ICollectionView ShownMercConfOptionsList
        {
            get
            {
                return this.shownMercConfOptionsList;
            }

            set
            {
                this.shownMercConfOptionsList = value;
                this.OnPropertyChanged("ShownMercConfOptionsList");
            }
        }

        public ICollectionView ShownMercTacticsList
        {
            get
            {
                return this.shownMercTacticsList;
            }

            set
            {
                this.shownMercTacticsList = value;
                this.OnPropertyChanged("ShownMercTacticsList");
            }
        }

        public ICollectionView ShownMercPvpTacticsList
        {
            get
            {
                return this.shownMercPvpTacticsList;
            }

            set
            {
                this.shownMercPvpTacticsList = value;
                this.OnPropertyChanged("ShownMercPvpTacticsList");
            }
        }

        public string TextFilter
        {
            get
            {
                return this.textFilter;
            }

            set
            {
                this.textFilter = value;
                this.OnPropertyChanged("TextFilter");
                this.UpdateTextFilter();
            }
        }

        public void Close()
        {
            if (this.SaveEnabled)
            {
                DialogResult result = MessageBox.Show(
                    "Would you like to save these configuration settings?",
                    "Message",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.SaveChanges();
                }
            }

            System.Windows.Application.Current.Shutdown();
        }

        public void ResetToDefaults()
        {
            this.HomConf.SetDefaults();
            this.MercConf.SetDefaults();
        }

        public void Revert()
        {
            this.HomConf.Revert();
            this.MercConf.Revert();
            H_Tactics.Load("H_Tactics.lua");
            M_Tactics.Load("M_Tactics.lua");
            PVP_Tact.Load("H_PVP_Tact.lua");
            M_PVP_Tact.Load("M_PVP_Tact.lua");
            this.ExtraConfigs.ForEach(c => c.Load());
        }

        public void SaveChanges()
        {
            this.SaveEnabled = false;
            this.RevertEnabled = false;

            this.HomConf.Save();
            this.MercConf.Save();

            this.ExtraConfigs.ForEach(c => c.Save());

            H_Tactics.Save("H_Tactics.lua");
            M_Tactics.Save("H_Tactics.lua");

            PVP_Tact.Save("H_PVP_Tact.lua");
            M_PVP_Tact.Save("M_PVP_Tact.lua");
        }

        public void UpdateShownHomOptions()
        {
            List<ConfigOption> filteredOptions = this.HomConfOptionsList
                .Where(
                    o => RelevantHomOptions.IsOptionRelevant(
                        o.Name,
                        this.SelectedHomunculusDisplayType,
                        this.SelectedSHomunculusDisplayType)).OrderBy(o => o.Name).ToList();

            ICollectionView source = CollectionViewSource.GetDefaultView(filteredOptions);
            source.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            this.ShownHomConfOptionsList = source;
            this.UpdateTextFilter();
        }

        public void UpdateShownMercOptions()
        {
            List<ConfigOption> orderedOptions = MercConfOptionsList.OrderBy(o => o.Name).ToList();

            ICollectionView source = CollectionViewSource.GetDefaultView(orderedOptions);
            source.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            this.ShownMercConfOptionsList = source;
            this.UpdateTextFilter();
        }

        public void UpdateTextFilter()
        {
            Predicate<object> filterPredicate = item => string.IsNullOrEmpty(this.textFilter)
                                                        || ((ConfigOption)item).Name.IndexOf(
                                                            this.textFilter,
                                                            StringComparison.OrdinalIgnoreCase) != -1;
            if (this.ShownHomConfOptionsList != null)
            {
                this.ShownHomConfOptionsList.Filter = filterPredicate;
            }

            if (this.ShownMercConfOptionsList != null)
            {
                this.ShownMercConfOptionsList.Filter = filterPredicate;
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
            {
                return;
            }

            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ConfigOptionOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.SaveEnabled = true;
            this.RevertEnabled = true;
            this.ResetToDefaultsEnabled = true;
        }

        private static void Import(string title, Action<string> loadAction)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.ValidateNames = true;
            openDialog.Filter = "(*.lua)|*.lua";
            openDialog.Title = title;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                loadAction(openDialog.FileName);
            }
        }

        private static void Export(string title, Action<string> saveAction)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.ValidateNames = true;
            saveDialog.Title = title;
            saveDialog.Filter = "(*.lua)|*.lua";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                saveAction(saveDialog.FileName);
            }
        }

        public void ExportHomunculusSettings()
        {
            Export("Export homunculus settings.", this.HomConf.Save);
        }

        public void ExportMercenarySettings()
        {
            Export("Export mercenary settings.", this.MercConf.Save);
        }

        public void ExportHomunculusTactics()
        {
            Export("Export homunculus tactics.", H_Tactics.Save);
        }

        public void ExportMercenaryTactics()
        {
            Export("Export mercenary tactics.", M_Tactics.Save);
        }

        public void ImportHomunculusSettings()
        {
            Import("Import homunculus settings.", this.HomConf.Open);
            this.homConfOptionsList = null;
            this.UpdateShownHomOptions();
        }

        public void ImportMercenarySettings()
        {
            Import("Import mercenary settings.", this.MercConf.Open);
            this.mercConfOptionsList = null;
            this.UpdateShownMercOptions();
        }

        public void ImportHomunculusTactics()
        {
            Import("Import homunculus tactics.", H_Tactics.Load);
        }

        public void ImportMercenaryTactics()
        {
            Import("Import mercenary tactics.", M_Tactics.Load);
        }
    }
}