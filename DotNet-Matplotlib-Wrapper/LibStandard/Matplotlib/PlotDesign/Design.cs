using System;
using System.Collections.Generic;
using System.Text;

namespace LibStandard.Matplotlib.PlotDesign
{
    public class Design<T, Q> : IDesign<T,Q>
    {
        public string Title { get; set; }
        public short TitleFontSize { get; set; }
        public string OutsideColor { get; set; }
        public string InsideColor { get; set; }
        public List<Tuple<T, string>> XTick { get; set; }
        public List<Tuple<Q, string>> YTick { get; set; }

        public Design()
        {
            XTick = new List<Tuple<T, string>>();
            YTick = new List<Tuple<Q, string>>();
        }
    }

    public interface IDesign<T, Q>
    {
        string Title { get; set; }
        short TitleFontSize { get; set; }
        string OutsideColor { get; set; }
        string InsideColor { get; set; }
        List<Tuple<T, string>> XTick { get; set; }
        List<Tuple<Q, string>> YTick { get; set; }
    }
}
