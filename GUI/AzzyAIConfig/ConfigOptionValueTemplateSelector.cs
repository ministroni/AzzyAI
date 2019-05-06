using System;
using System.Windows;
using System.Windows.Controls;

namespace AzzyAIConfig
{
    class ConfigOptionValueTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BoolValueTemplate { get; set; }

        public DataTemplate IntValueTemplate { get; set; }

        public DataTemplate EnumValueTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            ConfigOption option = item as ConfigOption;
            if(option == null)
            {
                return null;
            }

            switch (option.Type)
            {
                case ConfigOption.ValueType.Boolean:
                    return BoolValueTemplate;
                case ConfigOption.ValueType.Integer:
                    return IntValueTemplate;
                case ConfigOption.ValueType.Enumeration:
                    return EnumValueTemplate;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
