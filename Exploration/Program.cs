using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;

var t = new Test() {
    //Membre requis. Le programme ne compile pas si le membre `Name` n'est pas spécifié
    Name = "Toto"
};

class Test
{
    public required string Name { get; init; }
}



//void Display<T>(IEnumerable<T> xs) => Console.WriteLine("[{0}]", string.Join(", ", xs));

//SolveRaceConditionOneThread.Run();