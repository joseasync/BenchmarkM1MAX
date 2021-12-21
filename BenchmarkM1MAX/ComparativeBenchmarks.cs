using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkM1MAX.Dijkstra;
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
    private static readonly DijkstraService Dijkstra = new DijkstraService();

    private static int[,] Graph = new int[,]
    {
        {0, 4, 0, 0, 0, 0, 0, 8, 0},
        {4, 0, 8, 0, 0, 0, 0, 11, 0},
        {0, 8, 0, 7, 0, 4, 0, 0, 2},
        {0, 0, 7, 0, 9, 14, 0, 0, 0},
        {0, 0, 0, 9, 0, 10, 0, 0, 0},
        {0, 0, 4, 14, 10, 0, 2, 0, 0},
        {0, 0, 0, 0, 0, 2, 0, 1, 6},
        {8, 11, 0, 0, 0, 0, 1, 0, 7},
        {0, 0, 2, 0, 0, 0, 6, 7, 0}
    };

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


    //Get Universities
    [Benchmark(Baseline = true), BenchmarkCategory("Dijkstra")]
    public void GetDijkstraPathsValues()
    {
        Dijkstra.GetDijkstraShortestPaths(Graph, 0);
    }
}