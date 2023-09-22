using System.Text.RegularExpressions;
using Xunit;
namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void TestOfAttetions()
    {
        for (int i = 0; i < 200; ++i)
        {
            var str = Program.Attention();
            
            Assert.InRange(str.Length,5, 51);
        }
    }

    [Fact]
    public void TestOfResult()
    {
        var str = Program.MainMethod();
        Regex rg = new Regex("Hello, world!\nAndhiagain\n\\!{5,51}");
        Assert.Matches(rg, str);
    }
}