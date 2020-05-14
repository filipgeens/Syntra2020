using System;
using SyntraAB.Tools.CLI;

namespace ToolTestConsole {
	class Program {
		static void Main(string[] args) {
			CLIBase cli = new CLIBase();
			cli.Plugins.Add(new HalloCliPlugin());
			cli.Plugins.Add(new OlaPlugin());
			cli.Run(args);
		}
	}
}
