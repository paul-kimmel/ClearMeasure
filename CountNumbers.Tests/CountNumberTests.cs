using System.Text;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CountNumbers.Tests
{
  public class CountNumberTests
  {
    private readonly ITestOutputHelper output;
    private readonly TestOutputWriter writer;
    public CountNumberTests(ITestOutputHelper output /* IoC */)
    {
      this.output = output;
      this.writer = new TestOutputWriter(output);
    }

    [Fact]
    public void FirstTest()
    {
      var conditions = new List<Tuple<long, string>>() { Tuple.Create(3L, "Paul"), Tuple.Create(5L, "Kimmel") };
      var list = new UnboundedCounter(new Rules(conditions)).GetOutput(15);
      var builder = new StringBuilder();

      foreach (var s in list)
        builder.Append(s);

      var result = builder.ToString();
      output.WriteLine(result);
      Assert.True("12Paul4KimmelPaul78PaulKimmel11Paul1314Paul Kimmel" == result);
    }

    [Fact]
    public void FactoryMethodTest()
    {
      var conditions = new List<Tuple<long, string>>() { Tuple.Create(3L, "Paul"), Tuple.Create(5L, "Kimmel") };
      var list = UnboundedCounter.Create(15, conditions);

      var builder = new StringBuilder();

      foreach (var s in list)
        builder.Append(s);

      var result = builder.ToString();
      output.WriteLine(result);
      Assert.True("12Paul4KimmelPaul78PaulKimmel11Paul1314Paul Kimmel" == result);
    }

    [Fact]
    public void FactoryMethodTest_LargeSet()
    {
      var conditions = new List<Tuple<long, string>>() { Tuple.Create(3L, "Paul"), Tuple.Create(5L, "Kimmel"), Tuple.Create(10L, "Pollux") };

      var list = UnboundedCounter.Create(5000, conditions);

      Array.ForEach<string>(list.Take(20).ToArray(), x => output.WriteLine(x));

      output.WriteLine(list.Count(x => x.Contains("Pollux")).ToString());
      Assert.True(list.Count(x => x.Contains("Pollux")) == 500);
     
    }


    [Fact]
    
    public void FailsGuardCondition()
    {
      var conditions = new List<Tuple<long, string>>() { Tuple.Create(3L, "Paul"), Tuple.Create(5L, "Kimmel") };

      var action = () => new UnboundedCounter(new Rules(conditions)).GetOutput(-1).ToList(/* invoke state machine to check the guard */);
      Assert.Throws<ArgumentOutOfRangeException>(action);

    }


    [Fact]
    public void SanityTest()
    {
      Assert.True(true);
    }
  }
}