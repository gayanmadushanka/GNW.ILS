using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pervation.Presentation._Basic_Windows.CommonFieldValidations
{
    class PasswordConfirmationFieldValidation : ValidationRule
    {
        private string _ErrorMSG = "Confirmation Should not be Blank and \nShould match with the Password! \n";
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
            string[] Fields = {"",""};
            Fields= value.ToString().Split(',');            
            {
                if (Fields.Length == 2)
                {
                    string zPassword = Fields[0];
                    string zConfirm = Fields[1];

                    if (String.IsNullOrEmpty(zConfirm))
                    {
                        // ErrorMSG = "Confirmation Should not be Blank! \n";
                        return new ValidationResult(false, ErrorMSG);
                    }
                    else
                    {
                        if (zPassword != zConfirm)
                        {
                            // ErrorMSG = "Confirmation Should match with the Password! \n";
                            return new ValidationResult(false, ErrorMSG);
                        }
                    }
                }
             }
            return new ValidationResult(true, null);
        }
    }
   
}
