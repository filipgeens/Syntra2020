using System;

namespace CliExample {
	class Program {

		static void Main(string[] args) {
			CLIBase cli = new CLIBase();
			CliPlugin ext = new CliPlugin();
			cli.Plugin = ext;
			cli.Run(args);
		}
	}
}
