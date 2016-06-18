namespace GNW.ILS.WPF.CommonView
{
    /// <summary>
    /// Interaction logic for LoadingAnimation.xaml
    /// </summary>
    public partial class LoadingAnimation
    {
        public LoadingAnimation()
        {
            InitializeComponent();
            Common.FlowView.Push(this);
        }
    }
}
