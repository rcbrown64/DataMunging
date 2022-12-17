using DataMunging.Common.Utilities.FileSystem;
using DataMunging.Common.Utilities.Parsing;
using DataMunging.Data.DTOs;

var lines = new
{
    Weather = FileUtils.GetFileLines(@"Assets\weather.dat"),
    Football = FileUtils.GetFileLines(@"Assets\football.dat")
};

var minWeatherData = 
    (from line in lines.Weather
     let weatherData = FlatFileParser.Parse<WeatherData>(line)
     where weatherData.Dy != 0
     orderby weatherData.GetSpread()
     select weatherData).First();

var minFootballData =
    (from line in lines.Football
     let footballData = FlatFileParser.Parse<FootballData>(line)
     where footballData.Team != null
     orderby footballData.GetSpread()
     select footballData).First();

Console.WriteLine($"Smallest spread - Day: {minWeatherData.GetSubject()}, Spread width: {minWeatherData.GetSpread()}.");
Console.WriteLine($"Smallest spread - Team: {minFootballData.GetSubject()}, Spread width: {minFootballData.GetSpread()}.");