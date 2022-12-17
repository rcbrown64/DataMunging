namespace DataMunging.Data.Interfaces
{
    public interface IData
    {
        void SetSubject(object subject);
        void SetVal1(double val1);
        void SetVal2(double val2);

        object GetSubject();
        double GetVal1();
        double GetVal2();
        double[] SortedValues();
        double GetSpread();
    }
}
