using SyntraAB.Tools.CLI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolTestConsole {
	public class HalloCliPlugin :IPlugin {
		public string Name { get; } = "Hallo";

		public bool Execute(CLIBase parent, CliCommand Input) {
			if (Input.Command == "hallo") {
				Console.WriteLine("Hallo iedereen !!");
				return true;
			}
			return false;
		}

		public void ShowHelp() {
			Console.WriteLine("hallo");
		}
	}
}
