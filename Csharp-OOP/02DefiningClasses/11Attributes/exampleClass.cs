using System;

//Да поставям 2 класа в 1 cs файл е лоша практика, но в този случай не си заслужава

[Version(version = 1.1)]
class exampleClass
{

}

class GetAttribute
{
    static void Main()
    {
        Console.WriteLine("Current version of class {0} is {1:f}", typeof(exampleClass), ((Version)System.Attribute.GetCustomAttributes(typeof(exampleClass))[0]).version);
    }
}