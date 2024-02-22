using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountNumbers
{

  public class SimpleCounter
  {
    public static IEnumerable<string> GetOutput(long upperBound)
    {
      for (var i = 1; i <= upperBound; i++)
      {

        if (i % 3 == 0 && i % 5 == 0)
        {
          yield return "Paul Kimmel";
        }
        else if (i % 3 == 0)
        {
          yield return "Paul";
        }
        else if (i % 5 == 0)
        {
          yield return "Kimmel";
        }
        else
        {
          yield return i.ToString();
        }
      }
    }
  }
}
