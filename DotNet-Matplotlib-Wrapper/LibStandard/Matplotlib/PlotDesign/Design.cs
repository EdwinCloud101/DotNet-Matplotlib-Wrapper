using System;
using System.Collections.Generic;
using System.Text;

namespace LibStandard.Matplotlib.PlotDesign
{
    public class Design : IDesign
    {
        public string Title { get; set; }
        public short TitleFontSize { get; set; }
        public string OutsideColor { get; set; }
        public string InsideColor { get; set; }
    }

    public interface IDesign
    {
        string Title { get; set; }
        short TitleFontSize { get; set; }
        string OutsideColor { get; set; }
        string InsideColor { get; set; }
    }
}
