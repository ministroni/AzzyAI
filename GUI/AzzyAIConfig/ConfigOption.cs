using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using AzzyAIConfig.Annotations;

namespace AzzyAIConfig
{
    public class ConfigOption : INotifyPropertyChanged
    {
        private object value;

        public ConfigOption(PropertyInfo propertyInfo, object source)
        {
            this.Name = propertyInfo.Name;
            object[] attributes = propertyInfo.GetCustomAttributes(false);
            this.Description = attributes.OfType<DescriptionAttribute>().First().Description;
            this.Category = attributes.OfType<CategoryAttribute>().First().Category;

            if (propertyInfo.PropertyType == typeof(bool))
            {
                this.Type = ValueType.Boolean;
            }
            else if (propertyInfo.PropertyType == typeof(int))
            {
                this.Type = ValueType.Integer;
            }
            else if (propertyInfo.PropertyType.BaseType == typeof(Enum))
            {
                this.Type = ValueType.Enumeration;
                this.EnumValues = Enum.GetValues(propertyInfo.PropertyType).Cast<Enum>().ToList();
            }

            this.value = propertyInfo.GetGetMethod().Invoke(source, new object[0]);
            this.OptionUpdateAction = (value) => propertyInfo.GetSetMethod().Invoke(source, new[] { value });
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public object Value
        {
            get
            {
                return this.value;
            }

            set
            {
                int parsed;
                string stringValue = value as string;
                if (this.Type == ValueType.Integer && stringValue != null && !int.TryParse(stringValue, out parsed))
                {
                    return;
                }

                this.value = value;
                this.OptionUpdateAction(this.value);
                this.OnPropertyChanged("Value");
            }
        }

        public ValueType Type { get; set; }

        public List<Enum> EnumValues { get; set; }

        public Action<object> OptionUpdateAction { get; set; }

        public enum ValueType
        {
            Boolean,
            Integer,
            Enumeration
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
            {
                return;
            }

            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
