using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CountNumbers.Tests
{
  public class TestOutputWriter : TextWriter
  {

    private ITestOutputHelper output;

    public TestOutputWriter(ITestOutputHelper output)
    {
      this.output = output;
    }

    public override Encoding Encoding => Encoding.UTF8;

    public override void WriteLine(string? s)
    {
      try
      {
        if (output != null)
          output.WriteLine(s);
      }
      catch (System.InvalidOperationException)
      {
      }
    }

    public override void Write(string? s)
    {
      WriteLine(s);
    }
  }
}
