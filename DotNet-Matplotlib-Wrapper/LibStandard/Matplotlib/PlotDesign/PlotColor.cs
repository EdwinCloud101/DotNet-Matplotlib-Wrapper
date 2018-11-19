using System;
using System.Collections.Generic;
using System.Text;

namespace LibStandard.Matplotlib.PlotDesign
{
    public class PlotColor : IPlotColor
    {
        //
        public string OutsideColor { get; set; }

        public string InsideColor { get; set; }

        public PlotColor()
        {
            
        }
    }

    public interface IPlotColor
    {
        string OutsideColor { get; set; }
        string InsideColor { get; set; }
    }
}
