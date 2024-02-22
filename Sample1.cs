using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  public class Sample1
  {
    public static void Count()
    {
      for (var i = 1; i <= 100; i++)
      {

        if (i % 3 == 0 && i % 5 == 0)
        {
          Console.WriteLine("Paul Kimmel");
        }
        else if (i % 3 == 0)
        {
          Console.WriteLine("Paul");
        }
        else if (i % 5 == 0)
        {
          Console.WriteLine("Kimmel");
        }
        else
        {
          Console.WriteLine(i);
        }

      }

      Console.ReadLine();
    }
  }
}
