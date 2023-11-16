using Exploration.HashCode;
using Exploration.PerfView;
using System.Drawing;



const int NB_ITERATION = 100000;
int sharedCounter = 0;

void ModifyCounter(int nb)
{
    for (int i = 0; i < NB_ITERATION; ++i)
        sharedCounter += nb;
}

Task incTask = Task.Run(() => ModifyCounter(1));
Task decTask = Task.Run(() => ModifyCounter(-1));

Task.WaitAll(incTask, decTask);
Console.WriteLine($"sharedCounter: {sharedCounter}");


//var dicoTest = new DictionaryKeySearchTest();
//dicoTest.Run();

//Additions.Main();

//WaitBeforePrinting.WaitInALoop();

//WaitBeforePrinting.SychronousWait();

//WaitBeforePrinting.AsychronousWait();