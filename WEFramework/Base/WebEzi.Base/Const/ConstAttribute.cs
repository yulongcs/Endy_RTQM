using System;

namespace WebEzi.Base.Const
{
    [AttributeUsage(AttributeTargets.All)]
    public class ConstAttribute : Attribute
    {
        public ConstAttribute(string viewString)
        {
            this.ViewString = viewString;
        }

        public string ViewString { get; set; }
    }
}
