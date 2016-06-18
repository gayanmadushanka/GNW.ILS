using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MessageControl
{
    public enum MessageType
    {
        SUCCESS,
        FAIL,
        ERROR,
        WARNING,
        INFORMATION
    }

    public delegate void MessageViewClosed(MessageView messageView);

    public class MessageView : Control
    {
        private Button _btnOk;
        private TextBlock _txtBlock;
        private readonly string _msg;
        private readonly DispatcherTimer _dispatcherTimerForMessage = new DispatcherTimer();
        public event MessageViewClosed MessageViewCloseEvent;

        public MessageView(string msg, string title)
        {
            DefaultStyleKey = typeof(MessageView);
            _dispatcherTimerForMessage.Tick += dispatcherTimerForMessage_Tick;
            _dispatcherTimerForMessage.Interval = new TimeSpan(0, 0, 5);
            _dispatcherTimerForMessage.Start();
            _msg = msg;
        }

        public MessageView(string msg, int time)
        {
            DefaultStyleKey = typeof(MessageView);
            _dispatcherTimerForMessage.Tick += dispatcherTimerForMessage_Tick;
            _dispatcherTimerForMessage.Interval = new TimeSpan(0, 0, 5);
            _dispatcherTimerForMessage.Start();
            _msg = msg;
        }

        public MessageView(string msg, string title, MessageType mType)
        {
            DefaultStyleKey = typeof(MessageView);
            _dispatcherTimerForMessage.Tick += dispatcherTimerForMessage_Tick;
            _dispatcherTimerForMessage.Interval = new TimeSpan(0, 0, 5);
            _dispatcherTimerForMessage.Start();
            _msg = msg;
            SetMessageType(mType);
        }

        public MessageView(string msg, string title, int seconds)
        {
            DefaultStyleKey = typeof(MessageView);
            _dispatcherTimerForMessage.Tick += dispatcherTimerForMessage_Tick;
            _dispatcherTimerForMessage.Interval = new TimeSpan(0, 0, seconds);
            _dispatcherTimerForMessage.Start();
            _msg = msg;
        }

        public MessageView(string msg, string title, int seconds, MessageType mType)
        {
            DefaultStyleKey = typeof(MessageView);
            _dispatcherTimerForMessage.Tick += dispatcherTimerForMessage_Tick;
            _dispatcherTimerForMessage.Interval = new TimeSpan(0, 0, seconds);
            _dispatcherTimerForMessage.Start();
            _msg = msg;
            SetMessageType(mType);
        }

        public void SetMessageType(MessageType mType)
        {
            if (mType != MessageType.SUCCESS)
            {
                ResourceDictionary dict = new ResourceDictionary { Source = new Uri("/MessageControl;component/Themes/Style.xaml", UriKind.RelativeOrAbsolute) };
                Application.Current.Resources.MergedDictionaries.Add(dict);
                switch (mType)
                {
                    case MessageType.FAIL:
                        Style = (Style)Application.Current.Resources["ErrorMessageContentStyle"];
                        break;
                    case MessageType.ERROR:
                        Style = (Style)Application.Current.Resources["ErrorMessageContentStyle"];
                        break;
                    case MessageType.WARNING:
                        Style = (Style)Application.Current.Resources["WarningMessageContentStyle"];
                        break;
                    case MessageType.INFORMATION:
                        Style = (Style)Application.Current.Resources["InfomationMessageContentStyle"];
                        break;
                }
            }
        }

        private void dispatcherTimerForMessage_Tick(object sender, EventArgs e)
        {
            if (MessageViewCloseEvent != null)
            {
                MessageViewCloseEvent(this);
            }
            VisualStateManager.GoToElementState(this, "MessageClosedVisualState", true);
            _dispatcherTimerForMessage.Stop();
        }

        public override void OnApplyTemplate()
        {
            if (_btnOk == null)
                _btnOk = GetTemplateChild("btnOk") as Button;
            if (_btnOk != null) _btnOk.Click += _btnOk_Click;
            if (_txtBlock == null)
            {
                _txtBlock = GetTemplateChild("txtMessage") as TextBlock;
                if (_txtBlock != null) _txtBlock.Text = _msg;
            }
        }

        private void _btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (MessageViewCloseEvent != null)
            {
                MessageViewCloseEvent(this);
            }
            VisualStateManager.GoToElementState(this, "MessageClosedVisualState", true);
            _dispatcherTimerForMessage.Stop();
        }
    }
}
