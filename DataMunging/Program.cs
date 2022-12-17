using DataMunging.Common.Utilities.FileSystem;
using DataMunging.Common.Utilities.Parsing;
using DataMunging.Weather.DTOs;

var lines = FileUtils.GetFileLines(@"Assets\weather.dat");
var minSpreadData = 
    (from line in lines
     let weatherData = FlatFileParser.Parse<WeatherData>(line)
     where weatherData.Dy != 0
     orderby weatherData.MxT - weatherData.MnT 
     select weatherData).First();

Console.WriteLine($"Smallest spread - Day: {minSpreadData.Dy}, Spread width: {minSpreadData.MxT - minSpreadData.MnT}.");