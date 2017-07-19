﻿using System;
using System.Collections.Generic;
using C1.Xamarin.Forms.Chart;

namespace FlexChart101
{
    public static class ChartSampleFactory
    {
        //public static FlexChart GetFlexChartSample(ChartSample chartSample)
        //{
        //    switch (chartSample.SampleDataType)
        //    {
        //        case (int)ChartSampleDataType.SALES_EXPENSES_DOWNLOADS:
        //            return SalesExpensesDownloads();
        //        case (int)ChartSampleDataType.BUBBLE:
        //            return Bubble();
        //        //case (int)ChartSampleDataType.FINANCIAL:
        //        //    return FinancialChart();
        //    }
        //    return null;
        //}

        public static IEnumerable<SalesExpensesDownloadsEntity> CreateEntityList()
        {
            List<SalesExpensesDownloadsEntity> entityList = new List<SalesExpensesDownloadsEntity>();

            //TODO: add culture
            string[] countries = new string[] { "US", "Germany", "UK", "Japan", "Italy", "Greece" };

            Random random = new Random();

            for (int i = 0; i < countries.Length; i++)
            {
                double sales = random.NextDouble() * 10000;
                double expenses = random.NextDouble() * 5000;
                double downloads = Math.Round(random.NextDouble() * 20000);

                entityList.Add(new SalesExpensesDownloadsEntity(countries[i], sales, expenses, downloads, DateTime.Today.AddDays(i)));
            }
            return entityList;
        }

        public static IEnumerable<SalesExpensesDownloadsEntity> CreateEntityList2()
        {
            List<SalesExpensesDownloadsEntity> entityList = new List<SalesExpensesDownloadsEntity>();

            //TODO: add culture
            string[] countries = new string[] { "US", "Germany", "UK", "Japan", "Italy", "Greece" };

            Random random = new Random();

            for (int i = 0; i < countries.Length; i++)
            {
                double sales = random.Next(10, 50) * 100;
                double expenses = random.Next(10, 50) * 500;
                double downloads = random.Next(10, 50) * 200;

                entityList.Add(new SalesExpensesDownloadsEntity(countries[i], sales, expenses, downloads, DateTime.Today.AddDays(i)));
            }
            return entityList;
        }

        public static IEnumerable<ZonesData> GetZonesData(int nStudents,int nMaxPoints)
        {
            Random random = new Random();
            for (int i = 0; i < nStudents; i++)
            {
                yield return new ZonesData()
                {
                    Number = i,
                    Score = nMaxPoints * 0.5 * (1 + random.NextDouble()),
                };
            }
        }
        public static FlexChart SalesExpensesDownloads()
        {
            FlexChart chart = new FlexChart();

            chart.BindingX = "Name";

            //TODO: add culture
            chart.Series.Add(new ChartSeries() { SeriesName = "Sales", Binding = "Sales" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Expenses", Binding = "Expenses" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Downloads", Binding = "Downloads" });

            chart.ItemsSource = CreateEntityList();

            return chart;
        }
        private static FlexChart Bubble()
        {
            FlexChart chart = new FlexChart() { ChartType = ChartType.Bubble };

            chart.BindingX = "Name";

            chart.Series.Add(new ChartSeries() { SeriesName = "Sales", Binding = "Sales,Downloads" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Expenses", Binding = "Expenses,Downloads" });

            chart.ItemsSource = CreateEntityList();

            return chart;
        }
        public static List<FinancialData> FinancialData()
        {
            Random rnd = new Random();

            List<FinancialData> listdata = new List<FinancialData>();
            for (int i = 0; i < 20; i++)
            {
                FinancialData data = new FinancialData();
                data.Date = DateTime.Today.AddDays(i);

                if (i > 0)
                    data.Open = listdata[i - 1].Close;
                else
                    data.Open = 1000;

                data.High = data.Open + rnd.Next(20);
                data.Low = data.Open - rnd.Next(20);
                data.Close = rnd.Next((int)data.Low, (int)data.High);
                data.Volume = rnd.Next(40, 100);
                listdata.Add(data);
            }
            return listdata;
        }
        public static IEnumerable<ChartType> GetBasicChartTypes()
        {
            yield return ChartType.Column;
           yield return ChartType.Bar;
           yield return ChartType.Scatter;
           yield return ChartType.Line;
           yield return ChartType.LineSymbols;
           yield return ChartType.Area;
           yield return ChartType.Spline;
           yield return ChartType.SplineSymbols;
           yield return ChartType.SplineArea;
        }
    }

    public class ZonesData
    {
        public int Number { get; set; }
        public double Score { get; set; }
    }
}
