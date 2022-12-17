using DataMunging.Data.Interfaces;

namespace DataMunging.Data.DTOs
{
    public class WeatherData : IData
    {
        public int Dy { get; set; }
        public double MxT { get; set; }
        public double MnT { get; set; }

        #region IData Members
        public void SetSubject(object subject)
        {
            Dy = int.Parse(subject.ToString() ?? "0");
        }
        
        public void SetVal1(double val1)
        {
            MxT = val1;
        }

        public void SetVal2(double val2)
        {
            MnT = val2;
        }

        public object GetSubject() => Dy;
        
        public double GetVal1() => MxT;

        public double GetVal2() => MnT;

        public double[] SortedValues() => new[] { MxT, MnT };

        public double GetSpread() => SortedValues()[0] - SortedValues()[1];
        #endregion
    }
}
