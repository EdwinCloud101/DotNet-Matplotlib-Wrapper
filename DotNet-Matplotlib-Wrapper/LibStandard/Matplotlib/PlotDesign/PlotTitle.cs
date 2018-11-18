using System;
using System.Collections.Generic;
using System.Text;

namespace LibStandard.Matplotlib.PlotDesign
{
    public class PlotTitle : IPlotTitle
    {
        public string Title { get; }
        public int FontSize { get; }

        public PlotTitle(string title, int fontSize)
        {
            Title = title;
            FontSize = fontSize;
        }
    }

    public interface IPlotTitle
    {
        string Title { get; }
        int FontSize { get; }
    }
}
