﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using Telerik.Charting;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Pervation.Presentation.DashBoard.Chart.Linear
{
    public static class ChartSeriesTypeSwitch
    {
        public static readonly DependencyProperty SeriesTypeProperty = DependencyProperty.RegisterAttached("SeriesType",
            typeof(string), typeof(ChartSeriesTypeSwitch), new PropertyMetadata(OnSeriesTypeChanged));

        public static string GetSeriesType(DependencyObject obj)
        {
            return (string)obj.GetValue(SeriesTypeProperty);
        }

        public static void SetSeriesType(DependencyObject obj, string value)
        {
            obj.SetValue(SeriesTypeProperty, value);
        }

        private static void OnSeriesTypeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            RadCartesianChart chart = sender as RadCartesianChart;
            if (chart == null)
                return;

            string seriesType = e.NewValue as string;
            chart.Series.Clear();
            foreach (CartesianSeries series in GetSeries(chart, seriesType))
            {
                chart.Series.Add(series);
            }

            CategoricalAxis categoricalAxis = chart.HorizontalAxis as CategoricalAxis;
            if (categoricalAxis != null)
            {
                AxisPlotMode plotMode = AxisPlotMode.BetweenTicks;
                if (seriesType == "Area" || seriesType == "Spline Area")
                {
                    plotMode = AxisPlotMode.OnTicks;
                }
                categoricalAxis.PlotMode = plotMode;
            }
        }

        private static IEnumerable<CartesianSeries> GetSeries(RadCartesianChart chart, string seriesType)
        {
            List<CartesianSeries> generatedSeries = new List<CartesianSeries>();
            for (int i = 0; i < 4; i++)
            {
                CategoricalSeries series = null;
                switch (seriesType)
                {
                    case "Line":
                        series = new LineSeries();
                        break;
                    case "Spline":
                        series = new SplineSeries();
                        break;
                    case "Area":
                        series = new AreaSeries();
                        break;
                    case "Spline Area":
                        series = new SplineAreaSeries();
                        break;
                    case "Step Line":
                        series = new StepLineSeries();
                        break;
                    case "Step Area":
                        series = new StepAreaSeries();
                        break;
                    case "Bar":
                        series = new BarSeries();
                        break;

                }
                if (seriesType == "Line" || seriesType == "Spline")
                {
                    if (series != null) series.PointTemplate = chart.Resources[string.Format("PointTemplate{0}", i + 1)] as DataTemplate;
                }
                if (series != null)
                {
                    series.CategoryBinding = new PropertyNameDataPointBinding("Category");
                    series.ValueBinding = new PropertyNameDataPointBinding("Value");
                    series.SetBinding(CategoricalSeries.ItemsSourceProperty, new Binding(string.Format("Collection{0}", i + 1)));
                    series.SetBinding(CategoricalSeries.ShowLabelsProperty, new Binding("ShowLabels"));
                    series.SetBinding(BarSeries.LegendSettingsProperty, new Binding("Legend"));
                    //series.SetBinding(CategoricalSeries.CombineModeProperty, new Binding("SelectedCombineMode"));
                    generatedSeries.Add(series);
                }
            }
            return generatedSeries;
        }
    }
}
