// See https://aka.ms/new-console-template for more information
namespace Task1;

public class Program
{
    public static string Attention()
    {
        var r = new Random();
        
        var count = r.NextInt64(5, 51);
        string str = "";
        for (var i = 0; i < count; ++i)
        {
            str += '!';
        }

        return str;
    }

    public static string MainMethod()
    {
        var str = "Hello, world!\nAndhiagain\n";
        str += Attention();
        return str;
    }

    public static void Main()
    {
        Console.WriteLine(MainMethod());
    }
}