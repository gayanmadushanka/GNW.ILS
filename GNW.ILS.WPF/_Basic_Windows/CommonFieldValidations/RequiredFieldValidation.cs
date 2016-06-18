using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pervation.Presentation._Basic_Windows.CommonFieldValidations
{
    public class RequiredFieldValidation : ValidationRule
    {
        private string _ErrorMSG = "cannot leave blank! \n";
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
            string text = value.ToString();
            if (String.IsNullOrEmpty(text))
            {
                return new ValidationResult(false, ErrorField + " " + ErrorMSG);
            }
            return new ValidationResult(true, null);
        }
    }
}
