using System;

List<string> names = new List<string>{ "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Hank", "Ivy" };

// Utilisation de Lookup pour regrouper les noms par longueur
var lookupNames = names.ToLookup(name => name.Length);

// Accéder aux noms de longueur 5
Console.WriteLine("Noms de longueur 5 :");
foreach (string name in lookupNames[5])
    Console.WriteLine(name);
//Alice
//David
//Frank
//Grace

class Valeur : IEquatable<Valeur>
{
    public int Value { get; set; }

    public Valeur(int value)
    {
        Value = value;
    }

    public bool Equals(Valeur? other)
    {
        if (other == null) return false;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Valeur;
        return Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}


//SolveRaceConditionOneThread.Run();