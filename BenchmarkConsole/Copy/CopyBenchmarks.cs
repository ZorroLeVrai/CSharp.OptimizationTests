using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkConsole.Copy;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class CopyBenchmarks
{
    private ClonableClass cc = new ClonableClass();
    private CloneableRecord cr = new CloneableRecord();

    [Benchmark]
    public void ManualCopyOfClass()
    {
        var locCopy = new ClonableClass(cc);
    }

    [Benchmark]
    public void MemberWiseCopyOfClass()
    {
        var locCopy = cc.ShallowCopy();
    }

    [Benchmark]
    public void BuiltInCopyOfRecord()
    {
        var locCopy = cr with { };
    }

    private class ClonableClass
    {
        public int Integer { get; set; }
        public double Double { get; set; }
        public char Char { get; set; }
        public bool Bool { get; set; }
        public string Text { get; set; }

        public ClonableClass()
        {
            Integer = 0;
            Double = 0;
            Char = 'A';
            Bool = true;
            Text = string.Empty;
        }

        public ClonableClass(ClonableClass other)
        {
            Integer = other.Integer;
            Double = other.Double;
            Char = other.Char;
            Bool = other.Bool;
            Text = other.Text;
        }

        public ClonableClass ShallowCopy()
        {
            return (ClonableClass)this.MemberwiseClone();
        }
    }

    private record CloneableRecord(int Integer, double Double, char Char, bool Bool, string Text)
    {
        public CloneableRecord(): this(0,0,'A',true,string.Empty)
        { }
    }
}
