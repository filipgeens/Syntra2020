using SyntraAB.Tools.CLI;
using System;

namespace SerializeAndIODemo {
	class Program {
		static void Main(string[] args) {
			CLIBase cli = new CLIBase();
			cli.Plugins.Add(new JSonDemo());
			cli.Run(args);
		}
	}
}
