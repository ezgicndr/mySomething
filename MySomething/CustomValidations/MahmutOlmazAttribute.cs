using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySomething.CustomValidations
{
    public class MahmutOlmazAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            string val = value.ToString();
            if (val.ToUpper() == "MAHMUT")
            {
                ErrorMessage = "sen gelme mahmut";
                return false;
            }

            return true;
           
        }
    }
}