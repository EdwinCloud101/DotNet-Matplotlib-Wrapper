﻿using System;
using System.Collections.Generic;
using System.Text;
using LibStandard.Matplotlib.PlotDesign.TickDesign;

namespace LibStandard.Matplotlib.PlotDesign
{
    public class Design<T, Q> : IDesign<T, Q>
    {
        public bool HasGrid { get; set; }
        public ITitle Title { get; set; }
        public IPlotColor PlotColor { get; set; }
        public IXTick<DateTime> XTick { get; set; }
        public IYTick<decimal> YTick { get; set; }

        public Design(ITitle title)
        {
            Title = title;
        }

        public Design(ITitle title, IPlotColor plotColor) : this(title)
        {
            PlotColor = plotColor;
        }

        public Design(ITitle title, IPlotColor plotColor, bool hasGrid) : this(title, plotColor)
        {
            HasGrid = hasGrid;
        }

        public Design(ITitle title, IPlotColor plotColor, IXTick<DateTime> xTick, IYTick<decimal> yTick, bool hasGrid) : this(title, plotColor)
        {
            HasGrid = hasGrid;
            PlotColor = plotColor;
            XTick = xTick;
            YTick = yTick;
        }
    }

    public interface IDesign<T, Q>
    {
        bool HasGrid { get; set; }
        ITitle Title { get; set; }
        IPlotColor PlotColor { get; set; }
        IXTick<DateTime> XTick { get; set; }
        IYTick<decimal> YTick { get; set; }
    }
}
