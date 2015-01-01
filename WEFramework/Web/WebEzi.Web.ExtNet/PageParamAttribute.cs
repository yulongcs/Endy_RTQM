using System;

namespace WebEzi.Web.ExtNet
{
    [AttributeUsage(AttributeTargets.All)]
    public class PageParamAttribute : Attribute
    {
        public PageParamAttribute(bool isRequired)
        {
            this.IsRequired = isRequired;
        }

        public bool IsRequired { get; set; }
    }
}
