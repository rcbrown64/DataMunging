using DataMunging.Data.Interfaces;

namespace DataMunging.Data.DTOs
{
    public class FootballData : IData
    {
        public string? Team { get; set; }
        public double For { get; set; }
        public double Against { get; set; }

        #region IData Members
        public void SetSubject(object subject)
        {
            Team = subject.ToString();
        }

        public void SetVal1(double val1)
        {
            For = val1;
        }

        public void SetVal2(double val2)
        {
            Against = val2;
        }

        public object GetSubject() => Team;

        public double GetVal1() => For;

        public double GetVal2() => Against;
        
        public double[] SortedValues() => new[] { For, Against }.OrderByDescending(x => x).ToArray();

        public double GetSpread() => SortedValues()[0] - SortedValues()[1];
        #endregion
    }
}