using DataMunging.Common.Interfaces;
namespace DataMunging.Weather.DTOs
{
    public class WeatherData : IData
    {
        public int Dy { get; set; }
        public double MxT { get; set; }
        public double MnT { get; set; }
    }
}
