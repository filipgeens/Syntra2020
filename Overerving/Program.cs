using System;

namespace SyntraAB.Overerving.Test {
	class Program {
		static void Main(string[] args) {
			Zoo zollozjie = new Zoo();
			foreach (var dier in zollozjie.Dieren) {
				Console.WriteLine($"{dier}");			
				Console.WriteLine($"{dier.Naam} maakt volgend geluid: {dier.MaakGeluid()}");
			}
			Console.ReadKey();
		}
	}
}
