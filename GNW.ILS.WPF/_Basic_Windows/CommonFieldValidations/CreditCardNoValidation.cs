using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace Pervation.Presentation._Basic_Windows.CommonFieldValidations
{
    class CreditCardNoValidation : ValidationRule
    {
        private string _ErrorMSG = "should have Last 4 dights Only";
        private string _ErrorField;
        public string ErrorMSG
        {
            get { return _ErrorMSG; }
            set { _ErrorMSG = value; }
        }
        public string ErrorField
        {
            get { return _ErrorField; }
            set { _ErrorField = value; }
        }
        /* public string ErrorField
         {
             get { return _ErrorField; }
             set { _ErrorField = value; }
         }*/
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string zCredit_No = value.ToString().Trim();
            if (!String.IsNullOrEmpty(zCredit_No))
            {
                if (zCredit_No.Length != 4)
                {
                    return new ValidationResult(false, ErrorField + " " + ErrorMSG);
                }
                else
                {
                    char[] chEachChars = zCredit_No.ToCharArray();
                    foreach (char eachChar in chEachChars)
                    {
                        if (!Char.IsDigit(eachChar))
                        {
                            return new ValidationResult(false, ErrorField + " " + ErrorMSG);
                        }
                    }
                }
            }
            return new ValidationResult(true, null);
        }
    }        
}
