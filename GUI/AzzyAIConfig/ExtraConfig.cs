using System.ComponentModel;
using AzzyAIConfig.Annotations;
using System.IO;

namespace AzzyAIConfig
{
    public class ExtraConfig : INotifyPropertyChanged
    {
        private readonly string filename;
        private string text;

        public ExtraConfig(string title, string filename)
        {
            this.Title = title;
            this.filename = filename;
            this.Load();
        }

        public string Title { get; private set; }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                this.text = value;
                this.OnPropertyChanged("Text");
            }
        }

        public void Load()
        {
            if (File.Exists(this.filename))
            {
                this.Text = File.ReadAllText(this.filename);
            }
        }

        public void Save()
        {
            if (!File.Exists(this.filename))
            {
                File.CreateText(this.filename);
            }

            File.WriteAllText(this.filename, this.text);
        }

        public override string ToString()
        {
            return this.Title;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
