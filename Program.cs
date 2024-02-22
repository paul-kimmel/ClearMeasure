
//Homework:
//1. Test Cases

//example: 5 and jeff palermo
//example: 3 and paul (tuple) x some number of these
//put on git hub and send link to Rayne


using CountNumbers;
using System.Diagnostics;
using System.Linq.Expressions;

var conditions = new List<Tuple<long, string>>() { Tuple.Create(3L, "Paul"), Tuple.Create(5L, "Kimmel") };

try
{
  var list = new UnboundedCounter(new Rules(conditions)).GetOutput(15);

  foreach (var s in list)
  {
    Console.WriteLine(s);
  }
}
catch(Exception ex)
{
  Console.WriteLine(ex.Message);
}

Console.ReadLine();

