using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pervation.Presentation._Basic_Windows.CommonFieldValidations
{
    public class NumericFieldValidation : ValidationRule
    {
        private string _ErrorMSG = "should be numeric!";
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
            decimal DecNumber;

            if (Decimal.TryParse(value.ToString(), out DecNumber))
            {
                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, _ErrorField + " " + _ErrorMSG);
        }
    }
   
}
