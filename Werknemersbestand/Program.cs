
using System;

namespace Werknemersbestand {
	class Program {
		public static CLIBase Cli = new CLIBase();
		static void Main(string[] args) {
			Cli.Plugin = new WerknemerCli();
			Cli.Run(args);
		}
	}
}
