using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySomething.CustomValidations
{
    public class MyPasswordAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value==null)
            {
                return false;
            }

            string strVal = value.ToString();

            bool intVarmi = false;
            bool stringVarmi = false;
            foreach(var item in strVal)
            {
                if (Char.IsNumber(item))
                    intVarmi = true;
                else
                    stringVarmi = true;
            }

            if (stringVarmi && intVarmi)
            {
                return true;
            }
            else
            {
                ErrorMessage = "parola en az bir karakter ve en az bir rakam içermelidir";
                return false;
            }
            
        }
    }
}