using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WebEzi.Core.Domain.DefinedAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ModelPropertyCheckAttribute : Attribute
    {
        public bool AllowNull { get; set; }
        
        public object MinValue { get; set; }
        
        public object MaxValue { get; set; }

        public int MaxLength { get; set; }
    }
}
