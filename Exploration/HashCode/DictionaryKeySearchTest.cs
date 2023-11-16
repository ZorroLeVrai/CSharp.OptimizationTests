﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exploration.HashCode;

internal class DictionaryKeySearchTest
{
    private const int nbElements = 26;
    private readonly Dictionary<CustomKeyType, int> myDico = new Dictionary<CustomKeyType, int>(nbElements);

    public DictionaryKeySearchTest()
    {
        Console.WriteLine("Début initialisation du dico");

        for (int i = 0; i < 26; ++i)
        {
            var currentChar = (char)('A' + i);
            myDico[new CustomKeyType(currentChar)] = i+1;
        }

        Console.WriteLine("Fin initialisation du dico");
    }

    public void Run()
    {
        Console.WriteLine(myDico[new CustomKeyType('A')]);

        Console.WriteLine(myDico[new CustomKeyType('B')]);

        Console.WriteLine(myDico[new CustomKeyType('Z')]);
    }

    private class CustomKeyType : IEquatable<CustomKeyType>
    {
        public char Val { get; }

        public CustomKeyType(char v) => Val = v;

        public override bool Equals(object? obj)
        {
            var other = obj as CustomKeyType;
            return Equals(other);
        }

        public bool Equals(CustomKeyType? other)
        {
            if (other is null)
                return false;

            var result = (Val == other.Val);
            Console.WriteLine($"Equals ({Val}, {other.Val}) => {result}");
            return result;
        }

        public override int GetHashCode()
        {
            var hashCode = GetHashCodeWithCollision();
            Console.WriteLine($"GetHashCode {Val} => {hashCode}");
            return hashCode;

            int StandardGetHashCode() => Val.GetHashCode();

            int GetHashCodeWithCollision()
            {
                if (Val == 'A' || Val == 'Z')
                    return 1;
                return StandardGetHashCode();
            }
        }
    }
}
