using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AzzyAIConfig.Helpers
{
    public static class EnumHelper
    {
        public static EnumDescription Description(this Enum value)
        {
            EnumDescription enumDescription = new EnumDescription(value);
            object[] attributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            DescriptionAttribute description = attributes.OfType<DescriptionAttribute>().FirstOrDefault();
            if (description != null)
            {
                string[] values = description.Description.Split('|');
                enumDescription.Name = values.FirstOrDefault();
                enumDescription.Description = values.Skip(1).FirstOrDefault() ?? enumDescription.Name;
            }
            else
            {
                // No description found, so just try to build a friendly description
                enumDescription.Name = GetFriendlyText(value);
            }

            return enumDescription;
        }

        public static IEnumerable<EnumDescription> GetAllValuesAndDescriptions(Type t)
        {
            if (!t.IsEnum)
            {
                throw new ArgumentException(string.Format("{0} must be an enum type", t.Name));
            }

            return Enum.GetValues(t).Cast<Enum>().Select(e => e.Description()).OrderBy(e => e.Value).ToList();
        }

        private static string GetFriendlyText(Enum value)
        {
            return string.Join(" ", value.ToString().Split('_').Select(TitleCase));
        }

        private static string TitleCase(string value)
        {
            char[] returnValue = value.ToLower().ToCharArray();
            returnValue[0] = char.ToUpper(returnValue[0]);
            return new string(returnValue);
        }
    }
}
