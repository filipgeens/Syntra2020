using SyntraAB.Tools.CLI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolTestConsole {
	public class OlaPlugin :IPlugin {
		public string Name { get; } = "Ola plugin";

		public bool Execute(CLIBase parent, CliCommand Input) {
			if (Input.Command == "ola") {
				 Console.WriteLine("Ola Pola");
				return true;
			}
			return false;
		}

		public void ShowHelp() {
			Console.WriteLine("ola");
		}
	}
}
