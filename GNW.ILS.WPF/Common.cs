using System.Collections.Generic;
using System.Windows.Controls;
using GNW.ILS.WPF.CommonView;

namespace GNW.ILS.WPF
{
   public class Common
    {

       public static Stack<Control> FlowView = new Stack<Control>();
       public static Grid GdBodyContent;
       public static Button BtnLogout;


       public static Control GoBack()
       {
           FlowView.Pop();
           Control control = FlowView.Peek();
           AddView(control);
           return control;
       }

       public static void AddView(Control control)
       {
           GdBodyContent.Children.Clear();
           GdBodyContent.Children.Add(control);
       }

       public static void LoadProgressBar()
       {
           LoadingAnimation operation = new LoadingAnimation();
           AddView(operation);
       }

       public static string FirstName;
       public static string LastName;
       public static byte[] Image;
    }
}
