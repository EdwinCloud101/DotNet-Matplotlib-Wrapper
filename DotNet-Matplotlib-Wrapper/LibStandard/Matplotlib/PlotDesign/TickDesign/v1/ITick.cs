using System;
using System.Collections.Generic;
using System.Text;

namespace LibStandard.Matplotlib.PlotDesign.TickDesign
{
    public interface ITick<T>
    {
        List<Tuple<T, string>> Values { get; }
    }
}
