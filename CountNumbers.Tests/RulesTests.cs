using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;


namespace CountNumbers.Tests
{
  public class RulesTests
  {
    private readonly ITestOutputHelper output;
    private readonly TestOutputWriter writer;
    public RulesTests(ITestOutputHelper output /* IoC */)
    {
      this.output = output;
      this.writer = new TestOutputWriter(output);
    }

    [Theory]
    [InlineData(15, new long[]{1,3, 5, 15})]
    [InlineData(24, new long[] { 1, 2, 3, 4, 6, 8, 12, 24 })]
    [InlineData(5000, new long[] { 1, 2, 4, 5, 8, 10, 20, 25, 40, 50, 100, 125, 200, 250, 500, 625, 1000, 1250, 2500, 5000 })]
    public void FindAllFactorsTest(long bound, long[] targetFactors)
    {
      var conditions = new List<Tuple<long, string>>() { Tuple.Create(3L, "Paul"), Tuple.Create(5L, "Kimmel") };
      var o = new Rules(conditions);

      var factors = o.FindFactors(bound);

      Assert.True(targetFactors.SequenceEqual(factors));  

    }

    [Fact]
    public void TestIndexTest()
    {
      var conditions = new List<Tuple<long, string>>() { Tuple.Create(3L, "Paul"), Tuple.Create(5L, "Kimmel") };
      var o = new Rules(conditions);
      var result = o.TestIndex(15);

      output.WriteLine($"Condition: {result.Item1}, Phrase: {result.Item2}");
      Assert.True(result.Item2 == "Paul Kimmel");

    }


    [Fact]
    public void TestIndexTest_EmptyConditions()
    {
      var conditions = new List<Tuple<long, string>>();
      var o = new Rules(conditions);
      var result = o.TestIndex(15);

      output.WriteLine($"Condition: {result.Item1}, Phrase: {result.Item2}");
      Assert.True(result.Item2 == "");

    }



    [Fact]       
    public void TestIndexTest2()
    {
      var conditions = new List<Tuple<long, string>>() { Tuple.Create(3L, "Paul"), Tuple.Create(5L, "Kimmel"), Tuple.Create(6L, "Jeff") };
      var o = new Rules(conditions);
      var result = o.TestIndex(24);

      output.WriteLine($"Condition: {result.Item1}, Phrase: {result.Item2}");
      Assert.True(result.Item2 == "Paul Jeff");
    }



  }
}
