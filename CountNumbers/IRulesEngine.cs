using System;
using System.Linq;

namespace CountNumbers
{
  public interface IRulesEngine
  {
    (bool, string) TestIndex(long i);
  }
}
