// See https://aka.ms/new-console-template for more information

using BinomeFinderApp;

var teamGenerator = new TeamGenerator();
while (true)
{
    Console.WriteLine("Binômes générés:");
    var teams = teamGenerator.GenerateTeam();
    foreach(var team in teams)
    {
        Console.WriteLine(team);
    }

    Console.WriteLine("Pour continuer tapez entrée. Pour terminer tapez Q");
    var input = Console.ReadLine();
    if (input?.ToUpper() == "Q")
        break;
}





