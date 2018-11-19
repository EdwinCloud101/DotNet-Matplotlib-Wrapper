using System;
using System.Collections.Generic;
using System.Text;

namespace LibStandard.Matplotlib.PlotDesign.TickDesign
{
    public class YTick<T> : IYTick<T>
    {
        public List<Tuple<T, string>> Values { get; private set; }

        public YTick(List<Tuple<T, string>> values)
        {
            Values = values;
        }
    }

    public interface IYTick<T> : ITick<T>
    {
        
    }
}
