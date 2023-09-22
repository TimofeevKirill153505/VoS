
using System.IO.Compression;
using System.Net.Sockets;

namespace Task6Test;

public class UnitTest1
{
    [Fact]
    public void TestFileValidation()
    {
        var file = Path.Combine(Environment.CurrentDirectory, "file.txt");
        
        var f = File.Open(file, FileMode.Create);
        f.Close();

        Assert.True(Program.ValidPath(file));
        Assert.False(Program.ValidPath(file[new Range(0, file.Length - 1)]));
        Assert.False(Program.ValidPath(Environment.CurrentDirectory));
        Assert.False(Program.ValidPath("D:\\asdsadasd.txt"));
        Assert.False(Program.ValidPath("U:\\rt.ext"));
        Assert.False(Program.ValidPath("sdfghjklkuytdfgh"));
        
        File.Delete(file);
    }

    [Fact]
    public async void TestUrlCheck()
    {
        Func<Task> act = async () =>
        {
            await Program.GetResponseAsync("https://gggguuugugugu.com");
        };
        await Assert.ThrowsAsync<HttpRequestException>(act);

        await Program.GetResponseAsync("https://developer.mozilla.org/ru/docs/Web/HTTP/Status");
        
    }

    [Fact]
    public async void TestWritingToFile()
    {
        var path = Path.Combine(Environment.CurrentDirectory, "file.html");
        var file = File.Open(path, FileMode.Create);
        file.Close();
        
        var resp = await Program.GetResponseAsync("https://developer.mozilla.org/ru/docs/Web/HTTP/Status");
        Stream str = new MemoryStream();
        resp.Content.ReadAsStream().CopyTo(str);
        
        await Program.WriteToFileAsync(resp, path);
        
        StreamReader respSr = new StreamReader(str);
        StreamReader sr = new StreamReader(path);
        
        Assert.Equal(respSr.ReadToEnd(), sr.ReadToEnd());
        respSr.Close();
        sr.Close();
        File.Delete(path);
    }
}