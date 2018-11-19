using System;
using System.Collections.Generic;
using System.Text;

namespace LibStandard.Matplotlib.PlotDesign
{
    public class Title : ITitle
    {
        public string Text { get; set; }
        public short Font { get; set; }

        public Title(string text, short font)
        {
            Text = text;
            Font = font;
        }
    }

    public interface ITitle
    {
        string Text { get; set; }
        short Font { get; set; }
    }
}
