using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pervation.Presentation._Basic_Windows.CommonFieldValidations
{
    public class PercentageFieldValidation : ValidationRule
    {
        private string _ErrorMSG = "should be less than 100!";
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
            string zPercentage = value.ToString();
            if (Convert.ToInt32(zPercentage) <= 100)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, _ErrorField + " " + _ErrorMSG);
        }
    }

}
