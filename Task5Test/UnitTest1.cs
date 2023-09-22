
using System.Collections;

namespace Task5Test;

public class UnitTest1
{
    [Fact]
    public void TestExtentionCheck()
    {
        Assert.True(Program.IsMatchesExtention(@"C:\text.txt", "txt"));
        Assert.False(Program.IsMatchesExtention(@"C:\txt.ext", "txt"));
        Assert.False(Program.IsMatchesExtention(@"C:\txt.html", "txt"));
        Assert.True(Program.IsMatchesExtention(@"C:\text.ext", "ext"));
        Assert.True(Program.IsMatchesExtention(@"D:\txt\text.txt", "txt"));
        Assert.False(Program.IsMatchesExtention(@"C:\.txt\text.ext", "txt"));

    }

    [Fact]
    public void TestSearch()
    {
        var testFolder = Path.Combine(Environment.CurrentDirectory, "TestFolder");
        Directory.CreateDirectory(testFolder);
        
        var deffolder = Path.Combine(testFolder, "deffolder");
        Directory.CreateDirectory(deffolder);
        var dotext = Path.Combine(testFolder, ".ext");
        Directory.CreateDirectory(dotext);
        var dottxt = Path.Combine(testFolder, ".txt");
        Directory.CreateDirectory(dottxt);
        
        var deftxt = File.Open(Path.Combine(deffolder, "file.txt"), FileMode.Create);
        deftxt.Close();
        var defext = File.Open(Path.Combine(dotext, "file.ext"), FileMode.Create);
        defext.Close();
        var exttxt = File.Open(Path.Combine(dottxt, "ext.txt"), FileMode.Create);
        exttxt.Close();
        var txtext = File.Open(Path.Combine(dotext, "txt.ext"), FileMode.Create);
        txtext.Close();


        List<string> txts = new List<string>() { Path.Combine(deffolder, "file.txt"), Path.Combine(dottxt, "ext.txt") };
        List<string> exts = new List<string>() {Path.Combine(dotext, "file.ext"), Path.Combine(dotext, "txt.ext")};
        var txt_t = Program.GetPaths(testFolder, "txt");
        var ext_t = Program.GetPaths(testFolder, "ext");
        
        Assert.Equal(txts.Order() ,txt_t.Order());
        Assert.Equal(exts.Order() ,ext_t.Order());
        
        File.Delete(Path.Combine(dotext, "txt.ext"));
        File.Delete(Path.Combine(dottxt, "ext.txt"));
        File.Delete(Path.Combine(dotext, "file.ext"));
        File.Delete(Path.Combine(deffolder, "file.txt"));
        
        Directory.Delete(dottxt);
        Directory.Delete(dotext);
        Directory.Delete(deffolder);
        
        Directory.Delete(testFolder);
       
    }
}