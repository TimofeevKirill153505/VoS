using System.Text.RegularExpressions;

namespace Task4Test;

public class UnitTest1
{
    [Fact]
    public void TestRgb()
    {
        var str = Program.GenerateTable();
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(str);
        int count = 0;
        var nods = doc.GetElementsByTagName("table")[0].ChildNodes;
        Regex rg = new Regex(@"rgb\(([^,]+), ([^,]+), ([^,]+)\)");
        foreach (XmlNode node in nods)
        {
            Assert.Equal(node.Name, "tr");
            var attr = node.FirstChild.Attributes["style"];
           // Assert.Equal("", attr.Value);
            var matches = rg.Matches(attr.Value);
            //Assert.Equal(3, matches.Count);
            

            int r = Convert.ToInt32(matches[0].Groups[1].ToString());
            int g = Convert.ToInt32(matches[0].Groups[2].ToString());
            int b = Convert.ToInt32(matches[0].Groups[3].ToString());
            Assert.Equal(r,count);
            Assert.Equal(g,count);
            Assert.Equal(b,count);
            ++count;
        }
        
    }
}