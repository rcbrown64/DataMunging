using System.Text.RegularExpressions;
using DataMunging.Data.DTOs;
using DataMunging.Data.Interfaces;

namespace DataMunging.Common.Utilities.Parsing
{
    public static class FlatFileParser
    {
        /*
         * Football    - return subject, for, against, parse success
         * WeatherData - return subject, upper, lower, parse success
         */
        public static T Parse<T>(string input)
        {
            var patterns = new
            {
                Weather = @"^([\s0-9]{4})([\s0-9]{4})[\s*]{2}([\s0-9]{4}).*?$",
                Football = @"^[\d\s.]{7}([_a-zA-Z\s]{16})[\d\s]{6}[\d\s]{4}[\d\s]{6}([\d\s]{6})[\s-]{5}([\d\s]{6}).*$",
            };

            var regex = new Regex(typeof(T) == typeof(WeatherData) 
                ? patterns.Weather 
                : patterns.Football);
            var match = regex.Match(input);
            IData result = typeof(T) == typeof(WeatherData)
                ? new WeatherData()
                : new FootballData();

            if (match.Success)
            {
                var groups = match.Groups;
                result.SetSubject(groups[1].Value.Trim());
                result.SetVal1(int.Parse(groups[2].Value.Trim()));
                result.SetVal2(int.Parse(groups[3].Value.Trim()));
            }

            return (T)result;
        }
    }
}
