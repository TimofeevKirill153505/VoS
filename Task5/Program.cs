// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

namespace Task5;

public class Program
{
    public static bool IsMatchesExtention(string filename, string ext)
    {
        Regex rg = new Regex(@$".*\.{ext}$");
        return rg.IsMatch(filename);
    }
    
    public static LinkedList<string> GetPaths(string path, string ext)
    {
        var list = new LinkedList<string>();
        
        LinkedList<string> dirs = new LinkedList<string>();
        dirs.AddLast(path);

        while (dirs.Any())
        {
            var fold = dirs.First;
            
            foreach (var filename in Directory.GetFiles(fold.Value))
            {
                if (IsMatchesExtention(filename, ext)) list.AddLast(filename);
            }

            foreach (var dir in Directory.GetDirectories(fold.Value)) dirs.AddLast(dir);
            dirs.RemoveFirst();
        }
        
        return list;
    }
    
    public static void Main()
    {
        Console.WriteLine("Введите полный адрес папки");
        var path = Console.ReadLine();

        Console.WriteLine("Введите расширение файлов");
        var ext = Console.ReadLine();

        var files = GetPaths(path, ext);

        foreach (var file in files)
        {
            Console.WriteLine(file);
        }
    }
}