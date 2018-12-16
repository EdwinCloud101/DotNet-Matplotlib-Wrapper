using System;
using System.Collections.Generic;
using System.Text;

namespace LibStandard.Matplotlib.PlotDesign.TickDesign
{
    public class XTick<T> : IXTick<T>
    {
        public List<Tuple<T, string>> Values { get; private set; }

        public XTick(List<Tuple<T, string>> values)
        {
            Values = values;
        }

        public XTick()
        {
            
        }
    }

    public interface IXTick<T> : ITick<T>
    {
        
    }
}
