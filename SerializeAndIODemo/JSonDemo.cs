using System;
using System.Collections.Generic;
using System.Text;
using SyntraAB.Tools.CLI;
using System.Text.Json;
using System.Text.Json.Serialization;
using SyntraAB.Tools.Extensions;
using System.IO;

namespace SerializeAndIODemo {
	public class JSonDemo :IPlugin {
		public string Name { get => "Json Demo"; }

		PrivateData _data = null;
		string _json = null;
		string _bestand = null;

		public bool Execute(CLIBase parent, CliCommand input) {

			switch (input.Command) {
				case "json.demo":
					if (input.Parameters?.Count >= 4) {
						_data = new PrivateData() {
							VoorNaam = input.Parameters[0],
							AchterNaam = input.Parameters[1],
							RijksregisterNummer = input.Parameters[2],
							BankRekeningNummer = input.Parameters[3]
						};
						_data.Pincode = 1234;
						_data.PrivateRelaties.AddRange(new string[] { "Annabel", "Lola", "Colette" });
						_json = JsonSerializer.Serialize(_data, new JsonSerializerOptions() { WriteIndented = true, IgnoreNullValues = true });
						Console.WriteLine(_json);
					}
					break;
				case "json.save":
					if (Directory.Exists(Path.GetDirectoryName(BestandsNaam(input)))) {
						File.WriteAllText(BestandsNaam(input), _json);
						Console.WriteLine($"Uw data is opgeslagen in de file '{_bestand}'");
					} else {
						Console.WriteLine($"{Path.GetDirectoryName(_bestand)} is niet gekend");
					}
					break;
				case "json.load":
					if (File.Exists(BestandsNaam(input))) {
						_data = null;
						_json = File.ReadAllText(BestandsNaam(input));
						if (_json.NotEmpty()) {
							_data = JsonSerializer.Deserialize<PrivateData>(_json);
							if (_data != null) {
								Console.WriteLine(_data);
							}
						}
					}
					break;
						default:
					return false;
			}
			return true;
		}
		public string BestandsNaam(CliCommand input) {
			if (input.Parameters?.Count >= 1) {
				_bestand = input.Parameters[0];
			} else if (_bestand.IsEmpty()) {
				_bestand = $@"{Directory.GetCurrentDirectory().TrimEnd('\\')}\{Path.GetRandomFileName()}";
			}
			return _bestand;
		}
		public void ShowHelp() {
		}
	}
}
