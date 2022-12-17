using DataMunging.Common.Utilities.FileSystem;
using DataMunging.Common.Utilities.Parsing;
using DataMunging.Data.DTOs;
using DataMunging.Data.Interfaces;

var lines = new List<(Type Type, IEnumerable<string> Data)>()
{
    (typeof(WeatherData), FileUtils.GetFileLines(@"Assets\weather.dat")),
    (typeof(FootballData), FileUtils.GetFileLines(@"Assets\football.dat"))
};

foreach (var fileData in lines)
{
    var isWeather = fileData.Type == typeof(WeatherData);
    var query =
        (from line in fileData.Data
            let data = isWeather
             ? (IData)FlatFileParser.Parse<WeatherData>(line)
             : FlatFileParser.Parse<FootballData>(line)
         where data.GetVal1() != 0 && data.GetVal2() != 0
         orderby data.GetSpread()
         select data).First();
    
    Console.WriteLine($"Smallest spread - {(isWeather ? "Day" : "Team")}: {query.GetSubject()}, Spread width: {query.GetSpread()}.");
}
