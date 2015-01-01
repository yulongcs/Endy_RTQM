using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebEzi.Control.ExtNet
{
    public class ValidatorUtil
    {
        public static string GenerateValidatorJsCode(string validatorForm, string invalidHandle, string handle)
        {
            // Please Note: the Parameter of Ext.GetCmp  function has been changed from c.id to c.name after Ext.Net 2.2
            var js = @" var isValid = true;
                            var dom = {0}.getForm().dom;
                            var count = dom.length;
                            var firstInvalidControl;
                            for (var i = 0; i < count; i++) {
                                var c = dom[i];
                                var ec = Ext.getCmp(c.name);
                                if(ec && {0}.el.contains(ec.el)) {
                                    if (ec.isValid) {
                                        if (!ec.isValid() && isValid) {
                                            isValid = false;
                                            if(firstInvalidControl == null) {
                                                firstInvalidControl = ec;
                                            }
                                        }
                                    }
                                }
                            }
                            var invalidEvent = function(firstInvalidControl) {
                                {1}
                            }
                            if (!isValid) {
                                invalidEvent(firstInvalidControl);
                                firstInvalidControl.focus();
                                return false;
                            }
                        ";

            return js.Replace("{0}", validatorForm).Replace("{1}", invalidHandle) + handle;
        }
    }
}
