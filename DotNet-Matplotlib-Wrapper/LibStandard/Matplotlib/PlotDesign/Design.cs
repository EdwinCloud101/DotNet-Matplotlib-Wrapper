using System;
using System.Collections.Generic;
using System.Text;
using LibStandard.Matplotlib.PlotDesign.TickDesign;

namespace LibStandard.Matplotlib.PlotDesign
{
    public class Design<T, Q> : IDesign<T, Q>
    {
        public ITitle Title { get; set; }
        public IPlotColor PlotColor { get; set; }
        public IXTick<int> XTick { get; set; }
        public IYTick<decimal> YTick { get; set; }

        public Design(ITitle title)
        {
            Title = title;
        }

        public Design(ITitle title, IPlotColor plotColor) : this(title)
        {
            PlotColor = plotColor;
        }

        public Design(ITitle title, IPlotColor plotColor, IXTick<int> xTick, IYTick<decimal> yTick) : this(title, plotColor)
        {
            PlotColor = plotColor;
            XTick = xTick;
            YTick = yTick;
        }
    }

    public interface IDesign<T, Q>
    {
        ITitle Title { get; set; }
        IPlotColor PlotColor { get; set; }
        IXTick<int> XTick { get; set; }
        IYTick<decimal> YTick { get; set; }
    }
}
