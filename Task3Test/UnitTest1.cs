namespace Task3Test;

public class UnitTest1
{
    [Fact]
    public void TestIsLength()
    {
        Assert.True(Program.isLength("45"));
        Assert.False(Program.isLength("hhkg67kjhjk"));
        Assert.True(Program.isLength("41235"));
        Assert.False(Program.isLength("-6"));
        Assert.True(Program.isLength("8"));
        Assert.True(Program.isLength("2"));
        Assert.False(Program.isLength("-awfd"));
        Assert.False(Program.isLength("asdfasdf"));
        Assert.False(Program.isLength("787878787878787878787878787878787878787878"));
        Assert.False(Program.isLength("89j9898"));
    }

    [Fact]
    public void TestS()
    {
        Assert.Equal(Program.S(1000000, 100000), 1000000ul * 100000);
        Assert.Equal(Program.S(2147483647, 2147483647), 2147483647ul * 2147483647);
        Assert.Equal(Program.S(4050, 11), 4050ul * 11);
        Assert.Equal(Program.S(167, 567), 167ul * 567);
    }
}