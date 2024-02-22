using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CountNumbers
{
  public class UnboundedCounter
  {
    //Factory method to make it simple to use
    public static IEnumerable<string> Create(long upperBound, List<Tuple<long, string>> divisorPhrasePairs)
    {
      var o = new UnboundedCounter(new Rules(divisorPhrasePairs));
      return o.GetOutput(upperBound);
    }

    private IRulesEngine _rulesEngine;
    public UnboundedCounter(IRulesEngine rulesEngine /* supports IoC */)
    {
      _rulesEngine = rulesEngine;
    }

    public IEnumerable<string> GetOutput(long upperBound)
    {
      Guard(upperBound > 0, () => throw new ArgumentOutOfRangeException("upperBound", "Bound must be greater than 0"));

      
      for (var bound = 1; bound <= upperBound; bound++)
      {
        (bool testResult, string phrase) = _rulesEngine.TestIndex(bound);
        yield return testResult ? phrase : bound.ToString();
      }
    }

    private void Guard(bool test, Action action)
    {
      if (test == false)
        action();
    }
  }
}
