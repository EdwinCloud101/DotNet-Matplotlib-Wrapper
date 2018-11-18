using System;
using System.Collections.Generic;
using System.Text;

namespace LibStandard.Matplotlib.PlotOperation
{
    public class XyPair<T,Q>
    {
        public List<T> X { get; set; }
        public List<Q> Y { get; set; }

        public XyPair()
        {
            X = new List<T>();
            Y = new List<Q>();
        }
    }
}
