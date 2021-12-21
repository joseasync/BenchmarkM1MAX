using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkM1MAX.Factorial;
using BenchmarkM1MAX.Serializer;

namespace BenchmarkM1MAX;

[MemoryDiagnoser(true)]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory), CategoriesColumn]
[RPlotExporter]
public class ComparativeBenchmarks
{
    private static readonly FactorialCalculator Factorial = new FactorialCalculator();
    private static readonly WeatherSerializer Serializer = new WeatherSerializer();
    private static readonly WeatherForecast weatherForecastList = new WeatherForecast()
    {
        Date = DateTime.Parse("2021-12-21"),
        TemperatureCelsius = 25,
        Summary = "Hot"
    };

    //JSON Serializer
    [Benchmark(Baseline = true), BenchmarkCategory("JsonSerializer")]
    public void GetJsonAsStringSerializedFromNewtonsoft()
    {
        Serializer.SerializeWeatherForecastToJsonUsingNewtonsoft(weatherForecastList);
    }

    [Benchmark, BenchmarkCategory("JsonSerializer")]
    public void GetJsonAsStringSerializedFromTextJson()
    {
        Serializer.SerializeWeatherForecastToJson(weatherForecastList);
    }
    
    //Factorial
    [Benchmark(Baseline = true), BenchmarkCategory("Factorial")]
    public void GetFactorialIterativeResult()
    {
        Factorial.FactorialIterative(30);
    }

    [Benchmark, BenchmarkCategory("Factorial")]
    public void GetFactorialRecursiveResult()
    {
        Factorial.FactorialRecursive(30);
    }

    
}