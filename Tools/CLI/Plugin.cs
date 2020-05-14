using System;
using System.Collections.Generic;
using System.Text;

namespace SyntraAB.Tools.CLI {
	public interface IPlugin {
		string Name { get; }
		bool Execute(CLIBase parent, CliCommand Input);
		void ShowHelp();
	}
}
