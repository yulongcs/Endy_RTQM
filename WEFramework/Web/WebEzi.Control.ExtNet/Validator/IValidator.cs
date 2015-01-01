using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebEzi.Control.ExtNet
{
    public interface IValidator
    {
        string ValidatorForm { get; set; }
        string InvalidHandle { get; set; }
    }
}
