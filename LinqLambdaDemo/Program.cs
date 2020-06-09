using SyntraAB.Tools.CLI;
using System;

namespace LinqLambdaDemo {
  class Program {
    
    static void Main(string[] args) {
      CLIBase cli = new CLIBase();
      cli.Plugins.Add(new LinqDemoPlugin());
      cli.Run(args);
    }
  }
}
