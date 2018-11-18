using System.Collections.Generic;
using LibStandard.Matplotlib.PlotDesign;

namespace LibStandard.Matplotlib
{
    public class TwoListInput<T, Q> : ITwoListInput<T, Q>
    {
        public IDesign Design { get; set; }
        public string XLabel { get; set; }
        public List<T> XValues { get; set; }
        public string YLabel { get; set; }
        public List<Q> YValues { get; set; }

        public void AddX(List<T> list, string title)
        {
            XValues.AddRange(list);
            XLabel = title;
        }

        public void AddY(List<Q> list, string title)
        {
            YValues.AddRange(list);
            YLabel = title;
        }

        public TwoListInput()
        {
            XValues = new List<T>();
            YValues = new List<Q>();
        }
    }

    public interface ITwoListInput<T, Q>
    {
        IDesign Design { get; set; }
        string XLabel { get; set; }
        List<T> XValues { get; set; }

        string YLabel { get; set; }
        List<Q> YValues { get; set; }

        void AddX(List<T> list, string title);
        void AddY(List<Q> list, string title);
    }
}
