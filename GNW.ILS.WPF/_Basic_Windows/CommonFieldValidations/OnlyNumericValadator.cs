using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Pervation.Presentation._Basic_Windows.CommonFieldValidations
{
    public class OnlyNumericValadator
    {
        public static void IsTextAllowed(object sender)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                Int32 selectionStart = textBox.SelectionStart;
                Int32 selectionLength = textBox.SelectionLength;

                String newText = String.Empty;
                foreach (Char c in textBox.Text.ToCharArray())
                {
                    if (Char.IsDigit(c) || Char.IsControl(c)) newText += c;
                }

                textBox.Text = newText;

                textBox.SelectionStart = selectionStart <= textBox.Text.Length
                    ? selectionStart
                    : textBox.Text.Length;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void AllowOnlyDecimals (object sender)
        {
            try
            {
                    TextBox textBox = sender as TextBox;
                    Int32 selectionStart = textBox.SelectionStart;
                    Int32 selectionLength = textBox.SelectionLength;

                    String newText = String.Empty;
                    foreach (Char c in textBox.Text.ToCharArray())
                    {
                        if (newText.IndexOf(".") != -1)  //  has "."
                        { if (Char.IsDigit(c) || Char.IsControl(c)) newText += c; }
                        else { if (Char.IsDigit(c) || Char.IsControl(c)|| c.Equals('.')) newText += c; }
                    }

                    if (newText.IndexOf(".")==-1)           // not "."
                    {
                        newText = newText + ".00";
                    }
                    else if (newText.IndexOf(".") != -1)    //  has "."
                    {
                        string[] Nums = newText.Split('.');
                        string inte = Nums[0];
                        string decimals=Nums[1];

                        if(decimals.Length==0)
                        {
                            newText = inte + ".00";
                        }
                        else if (decimals.Length == 1)
                        {
                            newText = inte +"."+ decimals+"0";
                        }
                        else if (decimals.Length >= 2)
                        {
                            newText=  inte+"."+ decimals.Substring(0, 2);
                        }

                    }
                     textBox.Text = newText;

                    textBox.SelectionStart = selectionStart <= textBox.Text.Length ?
                        selectionStart : textBox.Text.Length;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void AllowOnly_0_Decimals(object sender)
        {
            try{
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;

            String newText = String.Empty;
            foreach (Char c in textBox.Text.ToCharArray())
            {
                if (newText.IndexOf(".") != -1)  //  has "."
                { if (Char.IsDigit(c) || Char.IsControl(c)) newText += c; }
                else { if (Char.IsDigit(c) || Char.IsControl(c) || c.Equals('.')) newText += c; }
            }

            if (newText.IndexOf(".") == -1)           // not "."
            {
                newText = newText + ".00";
            }
            else if (newText.IndexOf(".") != -1)    //  has "."
            {
                string[] Nums = newText.Split('.');
                string inte = Nums[0];
                string decimals = Nums[1];

               // if (decimals.Length == 0)

                {
                    newText = inte + ".00";
                }


               /* else if (decimals.Length == 1)
                {
                    newText = inte + "." + decimals + "0";
                }
                else if (decimals.Length >= 2)
                {
                    newText = inte + "." + decimals.Substring(0, 2);
                }*/

            }
            textBox.Text = newText;

            textBox.SelectionStart = selectionStart <= textBox.Text.Length ?
                selectionStart : textBox.Text.Length;
             }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void AllowOnly2Decimals(object sender)
        {
            try
            {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;

            String newText = String.Empty;
            foreach (Char c in textBox.Text.ToCharArray())
            {
                if (newText.IndexOf(".") != -1)  //  has "."
                { if (Char.IsDigit(c) || Char.IsControl(c)) newText += c; }
                else { if (Char.IsDigit(c) || Char.IsControl(c) || c.Equals('.')) newText += c; }
            }

            if (newText.IndexOf(".") == -1)           // not "."
            {
                newText = newText + ".00";
            }
            else if (newText.IndexOf(".") != -1)    //  has "."
            {
                string[] Nums = newText.Split('.');
                string inte = Nums[0];
                string decimals = Nums[1];

                if (decimals.Length == 0)
                {
                    newText = inte + ".00";
                }
                else if (decimals.Length == 1)
                {
                    newText = inte + "." + decimals + "0";
                }
                else if (decimals.Length >= 2)
                {
                    newText = inte + "." + decimals.Substring(0, 2);
                }

            }
            textBox.Text = newText;

            textBox.SelectionStart = selectionStart <= textBox.Text.Length ?
                selectionStart : textBox.Text.Length;
             }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void AllowOnly4Decimals(object sender)
        {
            try{
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;

            String newText = String.Empty;
            foreach (Char c in textBox.Text.ToCharArray())
            {
                if (newText.IndexOf(".") != -1)  //  has "."
                { if (Char.IsDigit(c) || Char.IsControl(c)) newText += c; }
                else { if (Char.IsDigit(c) || Char.IsControl(c) || c.Equals('.')) newText += c; }
            }

            if (newText.IndexOf(".") == -1)           // not "."
            {
                newText = newText + ".0000";
            }
            else if (newText.IndexOf(".") != -1)    //  has "."
            {
                string[] Nums = newText.Split('.');
                string inte = Nums[0];
                string decimals = Nums[1];

                if (decimals.Length == 0)
                {
                    newText = inte + ".0000";
                }
                else if (decimals.Length == 1)
                {
                    newText = inte + "." + decimals + "000";
                }
                else if (decimals.Length == 2)
                {
                    newText = inte + "." + decimals + "00";
                }
                else if (decimals.Length == 3)
                {
                    newText = inte + "." + decimals + "0";
                }
                else if (decimals.Length >= 4)
                {
                    newText = inte + "." + decimals.Substring(0, 4);
                }

            }
            textBox.Text = newText;

            textBox.SelectionStart = selectionStart <= textBox.Text.Length ?
                selectionStart : textBox.Text.Length;
             }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
