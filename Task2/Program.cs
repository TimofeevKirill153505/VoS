// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace Task2;



public class Person
{
    public string F { get; set; }
    public string I { get; set; }
    public int Age { get; set; }
    public override bool Equals(object? obj)
    {
        if (obj.GetType() != typeof(Person)) return false;
        var p = obj as Person;
        return F == p.F && p.I == I && Age == p.Age;
    }
}

public class Program
{
    public static bool IsNumber(string str)
    {
        int i = 0;
        try
        {
            i = Convert.ToInt32(str);
        }
        catch (Exception e)
        {
            return false;
        }

        if (i < 0) return false;
        
        return true;
    }
    public static bool IsAge(string str)
    {
        int age = 0;
        try
        {
            age = Convert.ToInt32(str);
        }
        catch (Exception e)
        {
            if (e is FormatException) return false;
        }

        if (age < 0 || age > 120) return false;
        
        return true;
    }

    public static void AddPersonToList(string f, string i, int age, List<Person> persons)
    {
        
        var p = new Person()
        {
            F = f,
            I = i,
            Age = age
        };
        persons.Add(p);
    }

    public static int LowestAge(List<Person> persons)
    {
        return persons.Select(p => p.Age).Min();
    }
    
    public static int BiggestAge(List<Person> persons)
    {
        return persons.Select(p => p.Age).Max();
    }
    
    public static double AverageAge(List<Person> persons)
    {
        return persons.Select(p => p.Age).Average();
    }
    
    public static void Main()
    {
        List<Person> persons = new List<Person>();
        int count = 0;
        while (true)
        {
            Console.WriteLine("Введите число людей:");
           
            var inp = Console.ReadLine();
            if (IsAge(inp))
            {
                count = Convert.ToInt32(inp);
                break;
            }
        }

        for (int j = 0; j < count; ++j)
        {
            Console.WriteLine("Введите Фамилию:");
            var f = Console.ReadLine();
            Console.WriteLine("Введите Имя:");
            var i = Console.ReadLine();
            int age = 0;
            
            while (true)
            {
                Console.WriteLine("Введите возраст:");
                var str = Console.ReadLine();
                if (!IsAge(str)) continue;
                age = Convert.ToInt32(str);
                break;
            }

            AddPersonToList(f, i, age, persons);
        }
        
        Console.WriteLine($"Самый малый возраст: {LowestAge(persons)}");
        Console.WriteLine($"Самый большой возраст: {BiggestAge(persons)}");
        Console.WriteLine($"Средний возраст: {AverageAge(persons)}");
    }
}