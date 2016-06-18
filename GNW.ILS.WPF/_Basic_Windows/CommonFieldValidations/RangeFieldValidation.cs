using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pervation.Presentation._Basic_Windows.CommonFieldValidations
{
    class RangeFieldValidation : ValidationRule
    {
        private static string _ErrorMSG = "";

        public static class CheckTypes
        {
            public  const string CheckLessThan = "CheckLessThan";
            public  const string CheckGraterThan = "CheckGraterThan";
            public  const string CheckLessThanOrEqual = "CheckLessThanOrEqual";
            public  const string CheckGraterThanOrEqual = "CheckGraterThanOrEqual";
            public  const string CheckEqual = "CheckEqual";
            public  const string CheckNotEqual = "CheckNotEqual";
        }

        public static string CheckMode;

        public static string _ValueLessThan;
        public static string _ValueGraterThan;

        public static string _ValueLessThanOrEqualTo;
        public static string _ValueGraterThanOrEqualTo;

        public static string _ValueEqualTo;
        public static string _ValueNotEqualTo;

        private string _ErrorField;
        private static bool _IsValid = true;

        public static bool IsValid
        {
            get { return _IsValid; }
            set { _IsValid = value; }
        }
        public  string ErrorMSG
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
            ValidationResult R;
            try
            {
                switch (CheckMode)
                {
                    case CheckTypes.CheckLessThan:
                        {
                            _IsValid = CheckLessThanTo(value);
                            break;
                        }
                    case CheckTypes.CheckGraterThan:
                        {
                            _IsValid = CheckGraterThanTo(value);
                            break;
                        }
                    case CheckTypes.CheckLessThanOrEqual:
                        {
                            _IsValid = CheckLessThanOrEqualTo(value);
                            break;
                        }
                    case CheckTypes.CheckGraterThanOrEqual:
                        {
                            _IsValid = CheckGraterThanOrEqualTo(value);
                            break;
                        }
                    case CheckTypes.CheckEqual:
                        {
                            _IsValid = CheckEqualTo(value);
                            break;
                        }
                    case CheckTypes.CheckNotEqual:
                        {
                            _IsValid = CheckNotEqualTo(value);
                            break;
                        }
                }

                if (_IsValid)
                {
                    R = new ValidationResult(_IsValid, null);
                }
                else
                {
                    R = new ValidationResult(_IsValid, ErrorField + " " + _ErrorMSG);
                }
            }
            catch (Exception ex) { R = new ValidationResult(_IsValid, null); }
            return R;
        }
        bool CheckLessThanTo(object value)
        {
            bool ok = true;
            try
            {
                decimal _dValue = Convert.ToDecimal(value);
                decimal _dValueLessThan = Convert.ToDecimal(_ValueLessThan);
                if (_dValue < _dValueLessThan)
                {

                }
                else
                {
                    ok = false;
                }
            }
            catch (Exception ex) { ok = false; }
            return ok;
        }
        bool CheckGraterThanTo(object value)
        {
            bool ok = true;
            try
            {
                decimal _dValue = Convert.ToDecimal(value);
                decimal _dValueGraterThan = Convert.ToDecimal(_ValueGraterThan);
                if (_dValue > _dValueGraterThan)
                {

                }
                else
                {
                    ok = false;
                }
            }
            catch (Exception ex) { ok = false; }
            return ok;
        }
        bool CheckLessThanOrEqualTo(object value)
        {
            bool ok = true;
            try
            {
                decimal _dValue = Convert.ToDecimal(value);
                decimal _dValueLessThanToEq = Convert.ToDecimal(_ValueLessThanOrEqualTo);
                if (_dValue <= _dValueLessThanToEq)
                {

                }
                else
                {
                    ok = false;
                }
            }catch(Exception ex)
            {
                ok = false; 
            }
            return ok;
        }
        bool CheckGraterThanOrEqualTo(object value)
        {
            bool ok = true;
            try
            {
                decimal _dValue = Convert.ToDecimal(value);
                decimal _dValueGraterThanOREq = Convert.ToDecimal(_ValueGraterThanOrEqualTo);
                if (_dValue >= _dValueGraterThanOREq)
                {

                }
                else
                {
                    ok = false;
                }
            }catch(Exception ex)
            { ok = false; }
            return ok;
        }

        bool CheckEqualTo(object value)
        {
            bool ok = true;
            try
            {
                decimal _dValue = Convert.ToDecimal(value);
                decimal _dValueEqTo = Convert.ToDecimal(_ValueEqualTo);
                if (_dValue == _dValueEqTo)
                {

                }
                else
                {
                    ok = false;
                }
            }
            catch (Exception ex) { ok = false; }
            return ok;
        }
        bool CheckNotEqualTo(object value)
        {
            bool ok = true;
            try
            {
                decimal _dValue = Convert.ToDecimal(value);
                decimal _dValueNotEqTo = Convert.ToDecimal(_ValueNotEqualTo);
                if (_dValue != _dValueNotEqTo)
                {

                }
                else
                {
                    ok = false;
                }
            }
            catch (Exception ex) { ok = false; }
            return ok;
        }
    }
}
