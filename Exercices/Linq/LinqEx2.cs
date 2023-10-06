﻿using System.Runtime.InteropServices;

namespace Exercices.Linq;

internal class LinqEx2 : RunBase<string[], Dictionary<string, int>>
{
    private Dictionary<string, int> ToOccurenceDico(IEnumerable<string> items)
    {
        return items
            .GroupBy(item => item)
            .ToDictionary(group => group.Key, group => group.Count());
    }

    private Dictionary<string, int> ToOccurenceDico2(IEnumerable<string> items)
    {
        return items
            .Aggregate(new Dictionary<string, int>(), (Dictionary<string, int> acc, string cur) =>
            {
                if (acc.TryGetValue(cur, out int occurence))
                    acc[cur] = occurence + 1;
                else
                    acc.Add(cur, 1);

                return acc;
            });
    }


    private Dictionary<string, int> ToOccurenceDico3(IEnumerable<string> items)
    {
        return items
            .Aggregate(new Dictionary<string, int>(), (Dictionary<string, int> acc, string cur) =>
            {
                ref var valOrNewOccurence = ref CollectionsMarshal.GetValueRefOrAddDefault(acc, cur, out var existed);

                if (existed)
                    ++valOrNewOccurence;
                else
                    valOrNewOccurence = 1;

                return acc;
            });
    }

    public override string[] Init()
    {
        return new string[] { "Pomme", "Banane", "Pomme", "Cerise", "Banane", "Pomme" };
    }

    public override Dictionary<string, int> Process(string[] input)
    {
        return ToOccurenceDico3(input);
    }

    public override void DisplayResult(Dictionary<string, int> output)
    {
        Console.WriteLine(output.ToPrettyString());
    }
}
