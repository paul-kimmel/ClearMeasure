using System;
using System.Linq;
using System.Text;

namespace CountNumbers
{
  public class Rules : IRulesEngine
  {

    private List<Tuple<long, string>> pairs = new List<Tuple<long, string>>();

    public Rules(List<Tuple<long, string>> divisorPhrasePairs)
    {
      pairs = divisorPhrasePairs;
    }

    public List<long> FindFactors(long bound)
    {
      var list = new List<long>();

      for (var i = 1; i <= bound; i++)
      {
        if (bound % i == 0)
          list.Add(i);
      }

      return list;
    }


    public (bool, string) TestIndex(long bound)
    {
      var factors = FindFactors(bound);
      var list = new List<string>();

      foreach(var factor in factors)
      {
        var found = pairs.Find(x => x.Item1 == factor);
        if (found != null)
          list.Add(found.Item2);
      }

      return (list.Count > 0, string.Join(' ', list.ToArray()));
    }
  }
}
