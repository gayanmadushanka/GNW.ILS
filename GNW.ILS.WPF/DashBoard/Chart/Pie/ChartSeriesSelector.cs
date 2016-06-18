using System.Collections.Generic;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Pervation.Presentation.DashBoard.Chart.Pie
{
    public class ChartSeriesSelector : FrameworkElement
    {
        /// <summary>
        /// Identifies the <see cref="Series"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SeriesProperty = DependencyProperty.Register("Series",
            typeof(List<PieSeries>),
            typeof(ChartSeriesSelector),
            new PropertyMetadata());

        /// <summary>
        /// Identifies the <see cref="Chart"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ChartProperty = DependencyProperty.Register("Chart",
            typeof(RadPieChart),
            typeof(ChartSeriesSelector),
            new PropertyMetadata());

        /// <summary>
        /// Identifies the <see cref="SelectedIndex"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex",
            typeof(int),
            typeof(ChartSeriesSelector),
            new PropertyMetadata(-1, OnSelectedIndexPropertyChanged));

        public ChartSeriesSelector()
        {
            Series = new List<PieSeries>();
        }

        public List<PieSeries> Series
        {
            get
            {
                return (List<PieSeries>)GetValue(SeriesProperty);
            }
            set
            {
                SetValue(SeriesProperty, value);
            }
        }

        public RadPieChart Chart
        {
            get
            {
                return (RadPieChart)GetValue(ChartProperty);
            }
            set
            {
                SetValue(ChartProperty, value);
            }
        }

        public int SelectedIndex
        {
            get
            {
                return (int)GetValue(SelectedIndexProperty);
            }
            set
            {
                SetValue(SelectedIndexProperty, value);
            }
        }

        private static void OnSelectedIndexPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as ChartSeriesSelector).OnSelectedIndexChanged((int)e.NewValue);
        }

        private void OnSelectedIndexChanged(int newIndex)
        {
            if (Chart == null || Series.Count <= newIndex)
            {
                return;
            }

            foreach (var series in Chart.Series)
            {
                series.Visibility = Visibility.Collapsed;
            }

            PieSeries selectedSeries = Series[newIndex];
            if (!Chart.Series.Contains(selectedSeries))
            {
                Chart.Series.Add(selectedSeries);
            }
            else
            {
                selectedSeries.Visibility = Visibility.Visible;
            }
        }
    }
}
