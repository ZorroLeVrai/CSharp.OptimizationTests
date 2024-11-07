using Exploration.Dictionaries;
using Exploration.HashCode;
using Exploration.Threading;


//new TaskReferencingObjects().
//    Run();

//new DictionaryKeySearchTest().Run();


//await new AsyncExample().Run();

//Additions.Main();

//WaitBeforePrinting.WaitInALoop();

//WaitBeforePrinting.SychronousWait();

//WaitBeforePrinting.AsychronousWait();

var myDico = new MyDico<string, int>();
char[] key = new char[2];

for (int i = 0; i < 26; ++i)
{
    key[0] = GetChar(i);
    for (int j = 0; j < 26; ++j)
    {
        key[1] = GetChar(j);
        var strKey = new string(key);
        var value = i * 26 + j;
        myDico.Add(strKey, value);
    }
}

//312
Console.WriteLine(myDico["MA"]);
//0
Console.WriteLine(myDico["AA"]);
//675
Console.WriteLine(myDico["ZZ"]);

Console.ReadLine();

char GetChar(int i) => (char)('A' + i);
