using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pervation.Presentation._Basic_Windows.CommonFieldValidations
{
  public  class DateTimeFieldValidation : ValidationRule
    {
        private string _ErrorMSG = "Blank or Invalid Date Format";
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
            string zDateTime = value.ToString();

            try
            {
                Convert.ToDateTime(zDateTime);
                return new ValidationResult(true, null);
            }
            catch (Exception ex)
            { return new ValidationResult(false, _ErrorMSG); }
        }
    }
}
