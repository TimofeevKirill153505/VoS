using System.Net;
using System.Xml;

namespace Task6;

public class Program
{
    public static bool ValidPath(string path)
    {
        try
        {
            var file = File.Open(path, FileMode.Truncate);
            file.Close();
        }
        catch (Exception ex)
        { 
            return false;
        }

        return true;
    }

    public static async Task<HttpResponseMessage> GetResponseAsync(string url)
    {
        HttpRequestMessage req = new HttpRequestMessage();
        req.RequestUri = new Uri(url);
        req.Method = HttpMethod.Get;
        
        HttpClient client = new HttpClient();
        var resp = client.Send(req);
        
        return resp;
    }

    public static async Task WriteToFileAsync(HttpResponseMessage resp, string path)
    {
        StreamReader sr = new StreamReader(resp.Content.ReadAsStream());

        var task = sr.ReadToEndAsync();
        StreamWriter sw = new StreamWriter(path);
        
        sw.Write(await task);
        sr.Close();
        sw.Close();
    }
    
    public static async Task Main()
    {
        HttpResponseMessage resp;
        while (true)
        {
            Console.WriteLine("Введите URL");
            string url = Console.ReadLine();
            var task = GetResponseAsync(url);
            try
            {
                resp = await task;
                break;
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Invalid host");
            }
        }

        string path = "";
        while (true)
        {
            Console.WriteLine("Введите полный адрес файла");
            path = Console.ReadLine();
            if (!ValidPath(path)) continue;
            break;
        }

        //Console.WriteLine($"Statsus {resp.StatusCode}");
        await WriteToFileAsync(resp, path);
    }
}