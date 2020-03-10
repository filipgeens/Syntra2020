
using System;
using System.Collections.Generic;
using System.Text;

namespace Werknemersbestand {
	public class WerknemerCli {
		Werknemersbestand werknemers = new Werknemersbestand();
		public virtual bool Execute(CLIBase parent, CliCommand Input) {
			switch (Input.Command) {
				case "add-werknemer":
					werknemers.Add(Input[0], Input[1]);
					return true;
				case "zoek-werknemer":
					var res=werknemers.ZoekOpNaam(Input[0]);
					foreach (Werknemer item in res) {
						Console.WriteLine(item);
					}
					return true;
			}
			return false;
		}

	}
}
