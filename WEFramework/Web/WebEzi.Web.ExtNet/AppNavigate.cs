using System;
using System.Collections;
using WebEzi.Base.DefinedData;
using WebEzi.Base.Exception;


namespace WebEzi.Web.ExtNet
{
    public class AppNavigate
    {
        private const string ParamFormat = @"{0}={1}&";

        public static string GetParamString(IPageParameter para)
        {
            string paraString = string.Empty;

            Type t = para.GetType();

            foreach (var p in t.GetProperties())
            {
                object objValue = p.GetValue(para, null);

                if (objValue != null)
                {
                    string value;
                    if (objValue is bool)
                    {
                        value = Convert.ToBoolean(objValue) ? "1" : "0";
                    }
                    else
                    {
                        value = objValue.ToString();
                    }

                    paraString += String.Format(ParamFormat, p.Name.ToLower(), value);
                }
            }

            if (!paraString.Equals(string.Empty))
            {
                paraString = paraString.Substring(0, paraString.Length - 1);
#if !DEBUG
                 paraString = EncodeBase64(paraString);
#endif
                paraString = "?" + paraString;
            }

            return paraString;
        }

        public static void BindPageParam(string query, IPageParameter para)
        {
            if (para != null)
            {
                var table = new Hashtable();

                if (!String.IsNullOrEmpty(query))
                {
#if !DEBUG
                    query = DecodeBase64(query);
#endif
                    foreach (var s in query.Substring(query.IndexOf('?') + 1).Split('&'))
                    {
                        string[] item = s.Split('=');

                        table.Add(item[0].ToLower(), item[1]);
                    }
                }
                else
                {
                    return;
                    //throw new PageParameterException("This page must have some paramemters.");
                }

                Type t = para.GetType();

                foreach (var p in t.GetProperties())
                {
                    bool isRequired = false;
                    string paraName = p.Name.ToLower();

                    object[] attributes = p.GetCustomAttributes(typeof(PageParamAttribute), false);
                    if (attributes.Length > 0)
                    {
                        var attribute = attributes[0] as PageParamAttribute;

                        if (attribute != null) isRequired = attribute.IsRequired;
                    }

                    object obj = table[paraName];

                    if (obj != null)
                    {
                        if (p.PropertyType == typeof(WEKey))
                        {
                            WEKey key = obj.ToString();
                            p.SetValue(para, key, null);
                        }
                        else if (p.PropertyType == typeof(bool))
                        {
                            if (obj.ToString() == "1")
                            {
                                p.SetValue(para, true, null);
                            }
                            else
                            {
                                p.SetValue(para, false, null);
                            }
                        }
                        else
                        {
                            p.SetValue(para, obj, null);
                        }
                    }
                    else
                    {
                        if (isRequired)
                        {
                            throw new PageParameterException("Must have the parameter " + paraName);
                        }
                    }
                }
            }
        }

        private static string EncodeBase64(string str)
        {
            return str;
            //string code = string.Empty;

            //if (!String.IsNullOrEmpty(str))
            //{
            //    code = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(str));
            //}

            //return code;
        }

        private static string DecodeBase64(string str)
        {
            return str;
            //string code = "";

            //if (!String.IsNullOrEmpty(str))
            //{
            //    code = System.Text.Encoding.Default.GetString(Convert.FromBase64String(str));
            //}

            //return code;
        }

    }
}
