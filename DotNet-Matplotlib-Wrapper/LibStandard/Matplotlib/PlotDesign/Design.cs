using System;
using System.Collections.Generic;
using System.Text;
using LibStandard.Matplotlib.PlotDesign.TickDesign;

namespace LibStandard.Matplotlib.PlotDesign
{
    public class Design<T, Q> : IDesign<T, Q>
    {
        public string XLabel { get; }
        public string YLabel { get; }
        public string ScatterSuffix { get; private set; }
        public decimal IncreaseTickRate { get; private set; }
        public bool HasGrid { get; set; }
        public ITitle Title { get; set; }
        public IPlotColor PlotColor { get; set; }
        public IXTick<T> XTick { get; set; }
        public IYTick<Q> YTick { get; set; }

        public Design(ITitle title)
        {
            Title = title;
        }

        public Design(ITitle title, IPlotColor plotColor) : this(title)
        {
            PlotColor = plotColor;
        }

        public Design(ITitle title, IPlotColor plotColor, bool hasGrid, decimal increaseTickRate, string scatterSuffix,string xLabel, string yLabel) : this(title, plotColor)
        {
            XLabel = xLabel;
            YLabel = yLabel;
            ScatterSuffix = scatterSuffix;
            IncreaseTickRate = increaseTickRate;
            HasGrid = hasGrid;
        }

        public Design(ITitle title, IPlotColor plotColor, IXTick<T> xTick, IYTick<Q> yTick, bool hasGrid) : this(title, plotColor)
        {
            HasGrid = hasGrid;
            PlotColor = plotColor;
            XTick = xTick;
            YTick = yTick;
        }
    }

    public interface IDesign<T, Q>
    {
        string ScatterSuffix { get; }
        bool HasGrid { get; set; }
        ITitle Title { get; set; }
        IPlotColor PlotColor { get; set; }
        IXTick<T> XTick { get; set; }
        IYTick<Q> YTick { get; set; }
        decimal IncreaseTickRate { get; }
        string XLabel { get; }
        string YLabel { get; }
    }
}
