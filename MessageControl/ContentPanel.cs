using System.Collections.Generic;
using System.Windows.Controls;

namespace MessageControl
{
    public class ContentPanel : Control
    {
        private static readonly List<ProgressBarView> ProgressBarControllerList = new List<ProgressBarView>();
        public static StackPanel MessageControllerStackPanel;

        public ContentPanel()
        {
            DefaultStyleKey = typeof(ContentPanel);
        }

        public static void ViewProgressBar(string progressBarText)
        {
            ProgressBarView progressBarController = new ProgressBarView();
            progressBarController.ProgressBarViewCloseEvent += progressBarController_progressBarViewCloseEvent;
            progressBarController.ProgressText = progressBarText;
            ProgressBarControllerList.Add(progressBarController);
            MessageControllerStackPanel.Children.Add(progressBarController);
        }

        public static void ViewProgressBar(string progressBarText, string progressbarTitle)
        {
            ProgressBarView progressBarController = new ProgressBarView();
            progressBarController.ProgressBarViewCloseEvent += progressBarController_progressBarViewCloseEvent;
            progressBarController.ProgressText = progressBarText;
            ProgressBarControllerList.Add(progressBarController);
            MessageControllerStackPanel.Children.Add(progressBarController);
        }

        private static void progressBarController_progressBarViewCloseEvent(ProgressBarView progressBarView)
        {
            MessageControllerStackPanel.Children.Remove(progressBarView);
        }

        public static void StopProgressBar(string progressBarText)
        {
            if (ProgressBarControllerList.Count != 0)
            {
                foreach (ProgressBarView item in ProgressBarControllerList)
                {
                    if (item.ProgressText == progressBarText)
                    {
                        MessageControllerStackPanel.Children.Remove(item);
                        ProgressBarControllerList.Remove(item);
                        break;
                    }
                }
            }
        }

        public static void ViewOkMessage(MessageView okMessageController)
        {
            okMessageController.MessageViewCloseEvent += okMessageController_messageViewCloseEvent;
            MessageControllerStackPanel.Children.Add(okMessageController);
        }

        private static void okMessageController_messageViewCloseEvent(MessageView messageView)
        {
            MessageControllerStackPanel.Children.Remove(messageView);
        }
    }
}
