namespace Task2Test;

public class UnitTest1
{
    private int _min = 7;
    private int _max = 67;

    private const int _maxAge = 121;
    
    public List<Person> GenerateList()
    {
        List<Person> persons = new List<Person>();
        var r = new Random();
        string f = "FIO";
        string i = "IO";
        for (int count = 0; count < 200; ++count)
        {
            persons.Add(new Person()
            {
                F=f + Convert.ToString(count),
                I=i+ Convert.ToString(count),
                Age = r.Next(0, _maxAge)
            });
        }

        return persons;
    }
    
    public (List<Person>, double) GenerateListWithKnownAverage()
    {
        List<Person> persons = new List<Person>();
        var r = new Random();
        string f = "FIO";
        string i = "IO";
        double average = 0;
        const int l = 200;
        for (int count = 0; count < l; ++count)
        {
            int age = r.Next(0, _maxAge);
            average += age;
            persons.Add(new Person()
            {
                F=f + Convert.ToString(count),
                I=i+ Convert.ToString(count),
                Age = age
            });
        }

        average /= l;
        return (persons , average);
    }
    
    public List<Person> GenerateListWithKnownMaxOrMin(bool isMax, int n)
    {
        List<Person> persons = new List<Person>();
        var r = new Random();
        string f = "FIO";
        string i = "IO";
        for (int count = 0; count < 200; ++count)
        {
            persons.Add(new Person()
            {
                F=f + Convert.ToString(count),
                I=i+ Convert.ToString(count),
                Age = isMax? r.Next(0, n):r.Next(n, _maxAge)
            });
        }

        return persons;
    }
    
    [Fact]
    public void TestIsAge()
    {
        
        Assert.True(Program.IsAge("35"));
        Assert.True(Program.IsAge("56"));
        Assert.False(Program.IsAge("-5"));
        Assert.True(Program.IsAge("0"));
        Assert.False(Program.IsAge("asddfd"));
        Assert.False(Program.IsAge("123"));
        Assert.False(Program.IsAge("123g"));
    }

    [Fact]
    public void TestIsNumber()
    {
        Assert.True(Program.IsNumber("45"));
        Assert.False(Program.IsNumber("hhkg67kjhjk"));
        Assert.True(Program.IsNumber("41235"));
        Assert.False(Program.IsNumber("-6"));
        Assert.True(Program.IsNumber("8"));
        Assert.True(Program.IsNumber("2"));
        Assert.False(Program.IsNumber("-awfd"));
        Assert.False(Program.IsNumber("asdfasdf"));
        Assert.False(Program.IsNumber("787878787878787878787878787878787878787878"));
        Assert.False(Program.IsNumber("89j9898"));
    }

    [Fact]
    public void TestAddingToList()
    {
        var lst = GenerateList();
        List<Person> persons = new List<Person>();
        foreach(var p in lst)
        {
            Program.AddPersonToList(p.F, p.I, p.Age, persons);
        }

        for (int i = 0; i < lst.Count; ++i)
        {
            Assert.Equal(lst[i], persons[i]);
        }
    }
    
    [Fact]
    public void TestMax()
    {

        var list = GenerateListWithKnownMaxOrMin(true, _max);
        list.Add(new Person()
        {
            I="Fio",
            F="F",
            Age = _max + 1
        });
        
        list.Add(new Person()
        {
            I="Fio",
            F="F",
            Age = _max - 1
        });
        Assert.Equal(_max + 1, Program.BiggestAge(list));
        
        list.Add(new Person()
        {
            I="Fio",
            F="F",
            Age = _max + 1
        });
        list.Add(new Person()
        {
            I="Fio",
            F="F",
            Age = _max + 1
        });
        
        Assert.Equal(_max + 1, Program.BiggestAge(list));
    }
    
    [Fact]
    public void TestMin()
    {

        var list = GenerateListWithKnownMaxOrMin(false, _max);
        list.Add(new Person()
        {
            I="Fio",
            F="F",
            Age = _min - 1
        });
        Assert.Equal(_min - 1, Program.LowestAge(list));
        
        list.Add(new Person()
        {
            I="Fio",
            F="F",
            Age = _min - 2
        });
        Assert.Equal(_min - 2, Program.LowestAge(list));

        list.Add(new Person()
        {
            I="Fio",
            F="F",
            Age = _min - 1
        });
        
        Assert.Equal(_min - 2, Program.LowestAge(list));
    }

    [Fact]
    public void TestAverage()
    {
        for (int i = 0; i < 10; ++i)
        {
            (var lst, double average) = GenerateListWithKnownAverage();
            Assert.Equal(average, Program.AverageAge(lst));
        }
    }
}