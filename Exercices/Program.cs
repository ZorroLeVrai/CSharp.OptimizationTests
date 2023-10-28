// See https://aka.ms/new-console-template for more information

var dico = new Dictionary<string, char>
{
    { "Artichaut", 'A' },
    { "Aubergine", 'A' },
    { "Betterave", 'B' },
    { "Blette", 'B' },
    { "Tomate", 'T' }
};

var resultDico = dico.ToLookup(item => item.Value, item => item.Key)
    .ToDictionary(item => item.Key, item => item.ToArray());

foreach (var (key, val) in resultDico)
{
    Console.WriteLine("{0}: {1}", key, string.Join(", ", val));
}

//A: Artichaut, Aubergine
//B: Betterave, Blette
//T: Tomate

//var prgm = new Ex03ConwaySeries();
//prgm.Run();
