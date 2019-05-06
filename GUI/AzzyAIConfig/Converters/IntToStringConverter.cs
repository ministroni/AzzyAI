using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace AzzyAIConfig
{
    public class IntToStringConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = value as string;
            if (string.IsNullOrEmpty(stringValue))
            {
                return -1;
            }

            if (stringValue == "-")
            {
                return stringValue;
            }

            int sign = stringValue.StartsWith("-") ? -1 : 1;
            return sign * int.Parse(new string(stringValue.Where(char.IsDigit).ToArray()));
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
