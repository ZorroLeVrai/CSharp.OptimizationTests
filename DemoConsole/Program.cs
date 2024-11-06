// See https://aka.ms/new-console-template for more information
using DemoConsole;

//var guid = Guid.NewGuid();

var guid = new Guid("3031f416-4eae-402b-8b0c-413968fc33c3");

var str = Convert.ToBase64String(guid.ToByteArray());
    //.Replace('/', '-')
    //.Replace('+', '_')
    //.Substring(0, 22);
Console.WriteLine(guid);
Console.WriteLine(str);