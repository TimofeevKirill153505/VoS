// See https://aka.ms/new-console-template for more information
namespace Task3;

public class Program
{
    public static UInt64 S(int a, int b)
    {
        return (ulong)a * (ulong)b;
    }
    
    public static bool isLength(string str)
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

    public static void Main()
    {
        int a = 0, b = 0;
        while (true)
        {
            Console.WriteLine("Введите длину первой стороны");
            var str = Console.ReadLine();
            if(!isLength(str)) continue;
            a = Convert.ToInt32(str);
            break;
        }
        
        while (true)
        {
            Console.WriteLine("Введите длину второй стороны");
            var str = Console.ReadLine();
            if(!isLength(str)) continue;
            b = Convert.ToInt32(str);
            break;
        }
        
        Console.WriteLine($"Вычисленная площадь: {S(a,b)}");
    }
}