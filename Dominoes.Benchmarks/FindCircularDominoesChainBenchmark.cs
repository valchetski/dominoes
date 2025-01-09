using BenchmarkDotNet.Attributes;
using Dominoes.Tests.TestsData;

namespace Dominoes.Benchmarks;

[MemoryDiagnoser]
public class FindCircularDominoesChainBenchmark
{
    [Benchmark]
    [ArgumentsSource(nameof(ValidData))]
    public List<Domino>? EulerianCircuitTest(string rawInput)
    {
        return EulerianCircuit.FindCircularDominoesChain(rawInput.ToDominoesList());
    }
    
    [Benchmark]
    [ArgumentsSource(nameof(ValidData))]
    public List<Domino>? RecursiveBacktrackingTest(string rawInput)
    {
        return RecursiveBacktracking.FindCircularDominoesChain(rawInput.ToDominoesList());
    }

    public static IEnumerable<object> ValidData()
    {
        return new DominoesValidTestData().Select(x => x.First());
    }
}