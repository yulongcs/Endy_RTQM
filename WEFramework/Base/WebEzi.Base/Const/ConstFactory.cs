using System;
using System.Collections.Generic;
using WebEzi.Base.DefinedData;

namespace WebEzi.Base.Const
{
    public class ConstFactory
    {
        public const string Null = "null";

        public static List<WEListItem> ConvertToListItemCollection<T>()
        {
            var type = typeof (T);

            var list = new List<WEListItem>();

            var fields = type.GetFields();

            for (int i = 1; i < fields.Length; i++)
            {
                var value = fields[i].Name;
                if (value.ToLower() != Null)
                {
                    var attributies = fields[i].GetCustomAttributes(typeof (ConstAttribute), false);

                    if (attributies.Length == 0)
                    {
                        list.Add(new WEListItem
                                     {
                                         Text = value,
                                         Value = value
                                     });
                    }
                    else
                    {
                        list.Add(new WEListItem
                                     {
                                         Text = (attributies[0] as ConstAttribute).ViewString,
                                         Value = (attributies[0] as ConstAttribute).ViewString
                                     });
                    }
                }
            }

            return list;
        }

        public static T ConvertToEnum<T>(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                value = Null;
            }

            // Get all feilds
            var fields = typeof (T).GetFields();
            for (int i = 1; i < fields.Length; i++)
            {
                // Get attributies
                var attributies = fields[i].GetCustomAttributes(typeof (ConstAttribute), false);

                if (value.ToLower() == fields[i].Name.ToLower() ||
                    (attributies.Length > 0 && (attributies[0] as ConstAttribute).ViewString == value))
                {
                    return (T) Enum.Parse(typeof (T), fields[i].Name);
                }
            }

            return (T) Enum.Parse(typeof (T), string.Empty);
        }

        public static string ConvertToString(object value)
        {
            // In the sql, string.empty means null.
            if (value.ToString().ToLower() == Null)
            {
                return string.Empty;
            }

            object[] attributies = null;

            // Get all feilds
            var fields = value.GetType().GetFields();

            for (int i = 1; i < fields.Length; i++)
            {
                if (value.ToString().ToLower() == fields[i].Name.ToLower())
                {
                    // Get attributies
                    attributies = fields[i].GetCustomAttributes(typeof (ConstAttribute), false);
                    break;
                }
            }

            // Get view string
            if (attributies == null || attributies.Length == 0)
            {
                return value.ToString();
            }
            else
            {
                return (attributies[0] as ConstAttribute).ViewString;
            }
        }
    }
}