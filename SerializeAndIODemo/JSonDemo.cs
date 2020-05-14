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
				case "json.add":
					if (input.Parameters?.Count >= 2) {
						_data = new PrivateData() {
							VoorNaam = input.Parameters[0],
							AchterNaam = input.Parameters[1],
							RijksregisterNummer = input.GetParameter(2, "---------"),
							BankRekeningNummer = input.GetParameter(3,"----------"),
						};
						if (DateTime.TryParse(input.GetParameter(4, DateTime.MinValue.ToString()), out DateTime bd)) { _data.GeboorteDatum = bd; }
						if (int.TryParse(input.GetParameter(5, "0000"), out int p)) { _data.Pincode = p; }
						for(int i=6;i<input.Parameters.Count;i++) {
							_data.PrivateRelaties.Add(input.Parameters[i]);
						}						
						_json = JsonSerializer.Serialize(_data, new JsonSerializerOptions() { WriteIndented = true, IgnoreNullValues = true });
						goto case "json.print";
					}
					break;
				case "json.print":
					if (_data != null) {
						Console.WriteLine("Data object content:");
						Console.WriteLine(_data);
						Console.WriteLine();
					}
					if (_json?.Length > 0) {
						Console.WriteLine("Json serialized data:");
						Console.WriteLine(_json);
						Console.WriteLine();
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
							goto case "json.print";
						}
					}
					break;
				case "json.list":
					string dir = input.GetParameter(0, Directory.GetCurrentDirectory());
					if (Directory.Exists(dir)) {
						Console.WriteLine($"Json files available in directory {dir}");
						foreach (string filePath in Directory.GetFiles(dir, "*.json") ?? new string[] { "--no files found--" }) {
							Console.WriteLine(filePath);
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
			if (Path.GetExtension(_bestand)?.ToLower() != ".json") { _bestand += ".json"; }
			return _bestand;
		}
		public void ShowHelp() {
			StringBuilder showHelp = new StringBuilder();
			showHelp.AppendLine(" Json commando's:");
			showHelp.AppendLine("\t json.load <path>  \t Laad het bestand <path> uit een json file");
			showHelp.AppendLine("\t json.add <voornaam> <achternaam> <rijksregister> <bankrekening> <geboortedatum> <pincode> <relaties>+"  );
			showHelp.AppendLine("\t\t geboortedatum in formaat dd/ mm / yyyy");
			showHelp.AppendLine("\t\t <relaties> onbeperkte ingave");
			showHelp.AppendLine("\t\t Indien een naam spaties bevat, gebruik ' ' ");
			showHelp.AppendLine("\t json.save <path>  \t Sla het bestand op als <path> ");
			showHelp.AppendLine("\t json.print        \t Druk de huidige informatie af");
			showHelp.AppendLine("\t json.list <dir>   \t Geef alle json files weer in de map <dir>");
			showHelp.AppendLine();
			Console.WriteLine(showHelp.ToString());
		}
	}
}
