namespace Exploration.Linq;

internal class GroupByVsLookupV2
{
    public void Run()
    {
        var elements = new[] {
            new Ident(4, 'A'),
            new Ident(4, 'B'),
            new Ident(8, 'C'),
            new Ident(8, 'D'),
            new Ident(12, 'F') };

        var resultat = elements
                    .ToLookup(element => element.Nombre);

        var resultat2 = elements
                    .GroupBy(element => element.Nombre);

        foreach (var element in resultat)
            Console.WriteLine(element);

        foreach (var element in resultat2)
            Console.WriteLine(element);

        foreach (var element in resultat2)
            Console.WriteLine(element);
    }

    record Ident(int Nombre, char Lettre);
}
