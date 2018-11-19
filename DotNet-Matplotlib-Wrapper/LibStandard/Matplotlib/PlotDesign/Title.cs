using System;
using System.Collections.Generic;
using System.Text;

namespace LibStandard.Matplotlib.PlotDesign
{
    public class Title : ITitle
    {
        public string Text { get; set; }
        public short FontSize { get; set; }

        public Title(string text, short fontSize)
        {
            Text = text;
            FontSize = fontSize;
        }
    }

    public interface ITitle
    {
        string Text { get; set; }
        short FontSize { get; set; }
    }
}
