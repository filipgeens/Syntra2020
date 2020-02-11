using System;

namespace SyntraAB.Types.Labo {
	class Program {
		public static string cursor = "cmd>";
		static void Main(string[] args) {
			bool doContinue = true;
			GetallenLabo getallen = new GetallenLabo();
			StringLabo text = new StringLabo();
			while (doContinue) {
				Console.WriteLine();
				Console.Write(cursor);
				string commandLine = Console.ReadLine();
				string[] parameters = commandLine?.Split(" ");
				if (parameters?.Length > 0) {
					string command = parameters[0]?.ToLower()?.Trim();
					if (!string.IsNullOrEmpty(command)) {
						switch (command) {
							case "graden":
							case "celcius":
								if (parameters.Length > 1 && int.TryParse(parameters[1], out int celcius)) {
									Console.WriteLine($"{celcius}°C is {getallen.CelciusNaarFahrenheit(celcius)}°F en {getallen.CelciusNaarKelvin(celcius)}K");
								} else goto default;
								break;
							case "veelvoud":
							case "isveelvoud":
							case "isveelvoudvan":
								if (parameters.Length > 2 && int.TryParse(parameters[1], out int getal) && int.TryParse(parameters[2], out int veelvoud)) {
									Console.WriteLine($"{getal} is {(getallen.IsEenVeelvoudVan(getal, veelvoud) ? "een" : "geen")} veelvoud van {veelvoud}");
								} else goto default;
								break;
							case "mijlnaarkm":
							case "mijlnaarkilometer":
							case "m=>km":
							case "mijl=>km":
								if (parameters.Length > 1 && double.TryParse(parameters[1], out double mijl)) {
									Console.WriteLine($"{mijl} mijl is {(getallen.MijlNaarKilometer(mijl) + 0.005).ToString("N2")} km");
								} else goto default;
								break;
							case "kmnaarmijl":
							case "kilometernaarmijl":
							case "km=>m":
							case "km=>mijl":
								if (parameters.Length > 1 && double.TryParse(parameters[1], out double km)) {
									Console.WriteLine($"{km} km is {(getallen.KilometerNaarMijl(km) + 0.005).ToString("N2")} mijl");
								} else goto default;
								break;
							case "verwijder":
							case "verwijderletter":
								if (parameters.Length > 2 && int.TryParse(parameters[1], out int pos)) {
									Console.WriteLine($"Verwijder letter {pos} van '{parameters[2]}' geeft '{text.VerwijderLetter(parameters[2], pos)}'");
								} else goto default;
								break;
							case "exit":
							case "quit":
							case "close":
								doContinue = false;
								break;
							case "cls":
							case "clear":
							case "clearscreen":
								Console.Clear();
								break;
							case "cursor":
								if (parameters.Length > 1 && !string.IsNullOrEmpty(parameters[1])) {
									cursor = parameters[1];
								} else goto default;
								break;
							default:
								Console.WriteLine($"Het commando '{(!string.IsNullOrEmpty(command) ? command : "<empty>")}' is niet gekend of heeft verkeerde parameters");
								break;
						}
					}
				}
			}
			Console.WriteLine("Dit programma werd beëindigd. Gelieve een willekeurige toets te drukken om af te sluiten.");
			Console.ReadKey();
		}
	}
}
