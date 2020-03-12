
using CliLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Werknemersbestand {
	public class WerknemerCli {
		Werknemersbestand werknemers = new Werknemersbestand();
		Werknemer current = null;

		public bool DoeNiets(CLIBase parent, CliCommand Input) { return false; }
		public bool Execute(CLIBase parent, CliCommand Input) {
			switch (Input.Command) {
				case "add-werknemer":
					current=werknemers.Add(Input[0], Input[1]);
					return current!=null;
				case "baas":
					if (Input[0]?.Length > 0) { Werknemer.Baas = Input[0]; }
					return true;
				case "lijst":
					foreach (var wn in werknemers.Lijst.Values) { Console.WriteLine(wn); }
					return true;
				case "set-id":
					if (current != null && Input[0]?.Length > 0) {
						return werknemers.ChangeID(current, Input[0]);
					}
					return false;
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
