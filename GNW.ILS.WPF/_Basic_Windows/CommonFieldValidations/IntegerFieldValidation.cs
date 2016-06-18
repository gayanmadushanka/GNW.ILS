using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pervation.Presentation._Basic_Windows.CommonFieldValidations
{
    public class IntegerFieldValidation : ValidationRule
    {
        private string _ErrorMSG = "should be an Integer!";
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
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
           int IntNumber;

            if (Int32.TryParse(value.ToString(), out IntNumber))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, _ErrorField + " " + _ErrorMSG);
        }               
    }

}
