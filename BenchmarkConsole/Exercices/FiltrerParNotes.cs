using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Operations;

namespace BenchmarkConsole.Exercices;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class FiltrerParNotes
{
    Ex02FiltrerParNotesV1? _filtrerParNotesV1;
    Ex02FiltrerParNotesV3? _filtrerParNotesV2;
    Ex02FiltrerParNotesV2? _filtrerParNotesV3;

    [GlobalSetup]
    public void SetupData()
    {
        _filtrerParNotesV1 = new Ex02FiltrerParNotesV1();
        _filtrerParNotesV1.Initialize();

        _filtrerParNotesV2 = new Ex02FiltrerParNotesV3();
        _filtrerParNotesV2.Initialize();

        _filtrerParNotesV3 = new Ex02FiltrerParNotesV2();
        _filtrerParNotesV3.Initialize();
    }

    [Benchmark]
    public void ProcessV1()
    {
        _filtrerParNotesV1!.Process();
    }

    [Benchmark]
    public void ProcessV2()
    {
        _filtrerParNotesV2!.Process();
    }

    [Benchmark]
    public void ProcessV3()
    {
        _filtrerParNotesV3!.Process();
    }
}
