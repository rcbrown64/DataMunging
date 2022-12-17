using System.Text.RegularExpressions;
using DataMunging.Weather.DTOs;

namespace DataMunging.Common.Utilities.Parsing
{
    public static class FlatFileParser
    {
        public static T Parse<T>(string input)
        {
            if (typeof(T) != typeof(WeatherData)) 
                throw new NotImplementedException();
            
            var pattern = @"^([\s0-9]{4})([\s0-9]{4})[\s*]{2}([\s0-9]{4}).*?$";
            var weatherData = new WeatherData();
                
            if (Regex.Match(input, pattern).Success)
            {
                var matches = Regex.Matches(input, pattern);
                weatherData.Dy = int.Parse(matches[0].Groups[1].Value);
                weatherData.MxT = int.Parse(matches[0].Groups[2].Value);
                weatherData.MnT = int.Parse(matches[0].Groups[3].Value);
            }
                
            return (T)(object)weatherData;
        }
    }
}
