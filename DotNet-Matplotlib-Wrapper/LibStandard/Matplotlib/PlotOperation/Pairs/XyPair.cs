using System.Collections.Generic;

namespace LibStandard.Matplotlib.PlotOperation.Pairs
{
    public class XyPair<T, Q> : IXyPair<T, Q>
    {
        public string Legend { get; private set; }
        public List<T> X { get; }
        public List<Q> Y { get; }
        public bool HasScatter { get; set; }
        public void AddX(T xValue)
        {
            X.Add(xValue);
        }

        public void AddY(Q yValue)
        {
            Y.Add(yValue);
        }

        public XyPair(string legend)
        {
            Legend = legend;
            X = new List<T>();
            Y = new List<Q>();
        }
    }

    public interface IXyPair<T, Q>
    {
        List<T> X { get; }
        List<Q> Y { get; }
        bool HasScatter { get; }
        void AddX(T xValue);
        void AddY(Q yValue);
        string Legend { get; }
    }
}
