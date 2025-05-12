// See https://aka.ms/new-console-template for more information

using ConsoleApp;
using ConsoleApp.Profiling;
using System.Text;


//new ConwaySeries()
//    .Run();

//new GenerateBinaryNumbers(20).DisplayAsync().Wait();

//new FibonacciSequence().Run();

//new ConwaySeries().Run();

//new WaitBeforeAction().Run();

//new TestRandomizeArray().Run();

Console.WriteLine(BeginEnd("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));

string BeginEnd(string chaine)
{
    return chaine.Substring(0, 2) + chaine.Substring(chaine.Length - 2);
}

string BeginEndV2(string chaine)
{
    ReadOnlySpan<char> span = chaine;
    var sb = new StringBuilder();
    
    sb.Append(span.Slice(0, 2));
    sb.Append(span.Slice(span.Length - 2));

    return sb.ToString();
}