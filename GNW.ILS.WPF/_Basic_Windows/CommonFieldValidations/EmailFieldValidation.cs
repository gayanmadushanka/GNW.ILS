using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace Pervation.Presentation._Basic_Windows.CommonFieldValidations
{
  public  class EmailFieldValidation : ValidationRule
    {
        private string _ErrorMSG = "Invalid Email Address";
        //private string _ErrorField;
        public string ErrorMSG
        {
            get { return _ErrorMSG; }
            set { _ErrorMSG = value; }
        }
        /* public string ErrorField
         {
             get { return _ErrorField; }
             set { _ErrorField = value; }
         }*/
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {

            string MatchEmailPattern =
                        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                     + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

            string zEmail = value.ToString();
            if (!string.IsNullOrEmpty(zEmail))
            {
                Regex regex = new Regex(MatchEmailPattern);
                Match match = regex.Match(zEmail);
                if (!match.Success)
                {
                    return new ValidationResult(false, ErrorMSG);
                }
            }

            return new ValidationResult(true, null);
        }
    }
   
}
