// See https://aka.ms/new-console-template for more information
namespace Task4;

public class Program
{
    public static string GenerateTable()
    {
        string str = "<!DOCTYPE Html><html><head><title>TableGrad</title></head><body><table style=\"border:0; border-spacing:0;\">";
        ulong step = 0x010101;

        for (ulong a = 0; a < 255; a += 1)
        {
            str += $"<tr><td style=\"background:rgb({a}, {a}, {a});\" width=\"100\" height=\"5\"></td></tr>";
        }

        str += "</table></body></html>";

        return str;
    }
    public static void Main()
    {
        string str = GenerateTable();
        //Console.WriteLine(Path.Combine(Environment.CurrentDirectory, "Gradient.html"));
        var sr = new StreamWriter("D:\\VerificationOfSoftware\\Lab1\\Lab1\\Task4\\Gradient.html");
        sr.Write(str);
        sr.Close();
    }
}