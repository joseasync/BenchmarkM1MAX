// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using BenchmarkM1MAX;
using BenchmarkM1MAX.Factorial;

Console.WriteLine("Running Benchmarks!");

BenchmarkRunner.Run<ComparativeBenchmarks>();

