using System.Collections.Generic;
using System.Windows.Controls;
using Pervation.Presentation.DashBoard.Chart.SmoothScrolling;
using Telerik.Windows.Controls.QuickStart;

namespace Pervation.Presentation.DashBoard.Chart.Linear
{
    public partial class uc_LinearChart
    {
        public uc_LinearChart(List<ChartData> currentStockBalance)
        {
            InitializeComponent();
            BindConfigurationPanel();
        }

        protected Panel ConfigurationPanel
        {
            get
            {
                return QuickStart.GetConfigurationPanel(this);
            }
        }

        private void BindConfigurationPanel()
        {
            if (ConfigurationPanel.DataContext == null)
            {
                ConfigurationPanel.DataContext = DataContext;
            }
        }
    }
}
