using System.Windows;
using System.Windows.Controls;

namespace MessageControl
{
    public delegate void ProgressBarViewClosed(ProgressBarView progressBarView);
    [TemplatePart(Name = "canvas", Type = typeof(Canvas))]
    [TemplatePart(Name = "btnProgressClose", Type = typeof(Button))]
    [TemplatePart(Name = "tbProgressText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "tbProgressPercentage", Type = typeof(TextBlock))]

    public class ProgressBarView : Control
    {
        private Canvas _canvas;
        private TextBlock _tbProgressText;
        private TextBlock _tbProgressPercentage;
        private Button _btnProgressClose;
        public string ProgressText;
        public string ProgressPercentage;
        public event ProgressBarViewClosed ProgressBarViewCloseEvent;

        public ProgressBarView()
        {
            DefaultStyleKey = typeof(ProgressBarView);
        }

        public override void OnApplyTemplate()
        {
            if (_canvas == null)
                _canvas = GetTemplateChild("canvas") as Canvas;
            if (_btnProgressClose == null)
                _btnProgressClose = GetTemplateChild("btnProgressClose") as Button;
            if (_btnProgressClose != null) _btnProgressClose.Click += _btnProgressClose_Click;
            if (_tbProgressText == null)
                _tbProgressText = GetTemplateChild("tbProgressText") as TextBlock;
            if (_tbProgressText != null) _tbProgressText.Text = ProgressText;
            if (_tbProgressPercentage == null)
                _tbProgressPercentage = GetTemplateChild("tbProgressPercentage") as TextBlock;
            if (_tbProgressPercentage != null) _tbProgressPercentage.Text = ProgressPercentage;
        }

        private void _btnProgressClose_Click(object sender, RoutedEventArgs e)
        {
            if (ProgressBarViewCloseEvent != null)
            {
                ProgressBarViewCloseEvent(this);
            }
            VisualStateManager.GoToElementState(this, "ProgressClosedVisualState", true);
        }
    }
}
