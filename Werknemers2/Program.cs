
using System;
using Werknemersbestand;

namespace Werknemers2 {
	class Program {
		
		static void Main(string[] args) {
			WerknemerCli werknemers = new WerknemerCli();
			CliLib.CLIBase cli = new CliLib.CLIBase();
			cli.Callback = werknemers.Execute;
			cli.Run(args);
		}
	}
}
